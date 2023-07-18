using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CaroGame
{
    class GameControl
    {
        private CaroGame form;
        private Panel pnl_BanCo;
        private List<Player> players;
        private Player currentPlayer;
        private Oco[,] matrix;
        private int soNutDaDanh;
        private bool ComputerFirst = false;

        public GameControl(CaroGame form, Panel pnl_BanCo)
        {
            this.form = form;
            this.pnl_BanCo = pnl_BanCo;
        }

        //Thiết lập các trạng thái cần thiêt
        #region properties
        public Panel Pnl_BanCo
        {
            get
            {
                return this.pnl_BanCo;
            }
            set
            {
                this.pnl_BanCo = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }

            set
            {
                currentPlayer = value;
            }
        }
        #endregion

        //Vẽ bàn cờ, sự kiện Click, các button hủy ván và chơi lại
        #region Vùng xử lý
        public void VeBanCo(bool computerMode)
        {
            matrix = new Oco[SoLieu.CHESS_BOARD_ROW, SoLieu.CHESS_BOARD_COLUMN];//vẽ ma trận có hàng = 18 và cột bằng 16 với các ô vuông size 24

            Point temp = new Point(0, 0);

            for (int i = 0; i < SoLieu.CHESS_BOARD_ROW; i++)
            {
                for (int j = 0; j < SoLieu.CHESS_BOARD_COLUMN; j++)
                {
                    Button btn = new Button()
                    {
                        Width = SoLieu.CHESS_SIZE,
                        Height = SoLieu.CHESS_SIZE,
                        Location = new Point(temp.X + SoLieu.CHESS_SIZE, temp.Y),
                        Tag = String.Format("{0};{1}", i, j)
                    };
                    btn.Click += btn_Click;
                    pnl_BanCo.Controls.Add(btn);
                    temp = btn.Location;
                    //tạo bàn cờ và gán hàng cột cho i j
                    matrix[i, j] = new Oco();
                    matrix[i, j].soHang = i;
                    matrix[i, j].soCot = j;
                }
                temp = new Point(0, temp.Y + SoLieu.CHESS_SIZE);


            }
            players = initPlayer(computerMode);
            soNutDaDanh = 0;

            //kiểm tra xem có phải máy đánh hay không?
            if (ComputerFirst)
            {
                MayDanh();
            }

        }

        public void huyVan()
        {
            pnl_BanCo.Controls.Clear();


            form.groupBox1.Enabled = true;
            form.btn_PvM.Enabled = true;
            form.btn_PvP.Enabled = true;

            form.btn_HuyVan.Enabled = false;
            form.btn_ChoiLai.Enabled = false;
        }

        //Tạo sự kiện click cho bàn cờ
        private void btn_Click(object sender, EventArgs e)
        {
            Console.Beep(587, 125);//dùng thư viện C# tạo ra tiếng beep
            Button btn = sender as Button;
            Console.WriteLine("Press: " + btn.Tag);
            if (!currentPlayer.IsComputer)
            {
                if (btn.Text != "") return;
            }
            btn.Text = currentPlayer.Mark;
            btn.ForeColor = currentPlayer.Color;

            String[] vt = btn.Tag.ToString().Split(';');
            int viTriHang = Int32.Parse(vt[0]);
            int viTriCot = Int32.Parse(vt[1]);



            matrix[viTriHang, viTriCot].SoHuu = CurrentPlayer;//Đánh dấu sở hữu của người chơi

            if (isEndGame(viTriHang, viTriCot))
            {
                EndGame();
                return;
            }
            ChangePlayer();
            if (form.computerMode && currentPlayer.IsComputer)
            {

                MayDanh();
            }


        }
        private void EndGame()
        {
            bool temp = players[1].IsComputer;
            Console.Beep(330, 125);
            DialogResult result = MessageBox.Show(currentPlayer.Mark + " thắng! Bạn có muốn chơi lại?", "Xác nhận", MessageBoxButtons.YesNo);
            huyVan();
            if (result == DialogResult.Yes)
            {
                VeBanCo(temp);
                form.groupBox1.Enabled = false;
                form.btn_HuyVan.Enabled = true;
                form.btn_ChoiLai.Enabled = true;
                if (temp)
                {
                    form.btn_PvP.Enabled = false;
                }
                else
                {
                    form.btn_PvM.Enabled = false;
                }


            }


        }

        //Kiểm tra xem đã kết thúc trận đấu chưa
        #region kiểm ra và kết thúc game
        #region kiểm tra hàng dọc, ngang, chéo chính, chéo phụ
        //Mỗi ô được xét sẽ có 3 trạng thái: 1 là X, 2 là O và 3 là chưa được sở hữu bởi ai đó tạm được đánh dấu là xxx

        //đếm bên trái và bên phải số quân cờ của player 
        private bool HangNgang(int i, int j)
        {
            int LCount = 0, RCount = 0;
            for (int k = j + 1; k < SoLieu.CHESS_BOARD_COLUMN; k++)
            {
                if (matrix[i, k].SoHuu.Mark == "xxx") break;
                if (matrix[i, k].SoHuu.Equals(CurrentPlayer))
                {
                    RCount++;
                }
                else
                {
                    break;
                }
            }

            for (int k = j; k >= 0; k--)
            {
                if (matrix[i, k].SoHuu.Mark == "xxx") break;
                if (matrix[i, k].SoHuu.Equals(CurrentPlayer))
                {
                    LCount++;
                }
                else
                {
                    break;
                }
            }
            return LCount + RCount >= 5;
        }

        //đếm bên trên và bên dưới
        private bool HangDoc(int i, int j)
        {
            int TCount = 0, BCount = 0;

            for (int k = i + 1; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (matrix[k, j].SoHuu.Mark == "xxx") break;
                if (matrix[k, j].SoHuu.Equals(CurrentPlayer))
                {
                    BCount++;
                }
                else
                {
                    break;
                }
            }

            for (int k = i; k >= 0; k--)
            {
                if (matrix[k, j].SoHuu.Mark == "xxx") break;
                if (matrix[k, j].SoHuu.Equals(CurrentPlayer))
                {
                    TCount++;
                }
                else
                {
                    break;
                }
            }

            return TCount + BCount >= 5;
        }
        //Đếm góc trên bên trái vài góc dưới bên phải
        private bool CheoChinh(int i, int j)
        {
            int RCount = 0;
            int l = j;
            for (int k = i; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (l >= SoLieu.CHESS_BOARD_COLUMN) break;
                if (matrix[k, l].SoHuu.Mark == "xxx") break;
                if (!matrix[k, l].SoHuu.Equals(currentPlayer)) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    RCount++;
                }
                l++;
            }
            l = j;
            int LCount = -1;
            for (int k = i; k >= 0; k--)
            {
                if (l < 0) break;
                if (matrix[k, l].SoHuu.Mark == "xxx") break;
                if (!matrix[k, l].SoHuu.Equals(currentPlayer)) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    LCount++;
                }
                l--;
            }

            return LCount + RCount >= 5;
        }

        //đếm góc trên bên phải và góc dưới bên trái
        private bool CheoPhu(int i, int j)
        {
            int LCount = 0;
            int l = j;
            for (int k = i; k < SoLieu.CHESS_BOARD_ROW; k++)
            {
                if (l < 0) break;
                if (matrix[k, l].SoHuu.Mark == "xxx") break;
                if (!matrix[k, l].SoHuu.Equals(currentPlayer)) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    LCount++;
                }
                l--;
            }
            int RCount = -1;
            l = j;
            for (int k = i; k >= 0; k--)
            {
                if (l >= SoLieu.CHESS_BOARD_COLUMN) break;
                if (matrix[k, l].SoHuu.Mark == "xxx") break;
                if (!matrix[k, l].SoHuu.Equals(currentPlayer)) break;
                if (matrix[k, l].SoHuu.Equals(currentPlayer))
                {
                    RCount++;
                }
                l++;
            }

            return LCount + RCount >= 5;
        }
        #endregion
        private bool isEndGame(int i, int j)
        {
            if (HangNgang(i, j) || HangDoc(i, j) || CheoChinh(i, j) || CheoPhu(i, j))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Tạo list player và đổi người chơi đang đánh

        private List<Player> initPlayer(bool computerMode)
        {
            Player player1;
            Player player2;

            List<Player> players = new List<Player>();
            if (form.getRadioButonX().Checked == true)
            {
                player1 = new Player(0, "X");
                player2 = new Player(1, "O");

            }
            else
            {
                player1 = new Player(1, "O");
                player2 = new Player(0, "X");
            }

            players.Add(player1);
            players.Add(player2);
            currentPlayer = players[0];

            if (computerMode)
            {
                player2.IsComputer = true;
                Random rd = new Random();
                ComputerFirst = rd.Next(3, 50) % 2 == 1;
                if (ComputerFirst)
                {
                    currentPlayer = players[1];
                }

            }
            form.lblLuotDi.Text = currentPlayer.Mark;//đánh dấu
            form.lblLuotDi.ForeColor = currentPlayer.Color;//tô màu
            return players;
        }

        private void ChangePlayer()
        {
            currentPlayer = currentPlayer.Id == players[0].Id ? players[1] : players[0];
            soNutDaDanh++;
            form.lblLuotDi.Text = currentPlayer.Mark;//đánh dấu
            form.lblLuotDi.ForeColor = currentPlayer.Color;//tô màu
        }
        #endregion

        #endregion

        //vùng thuật toán AI
        #region Xử lý để máy đánh và cắt tỉa cây

        //mảng điểm tấn công, phòng ngự:
        //khai báo 1 mảng giá trị 
        private int[] MangDiemTanCong = new int[7] { 0, 4, 25, 246, 7300, 16561, 59049 };
        private int[] MangDiemPhongNgu = new int[7] { 0, 3, 24, 243, 2197, 19773, 177957 };




        //các hàm duyệt tấn công
        #region Tấn Công
        private int duyetTCDoc(int dongHT, int cotHT)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichTren = 0;
            int SoQuanDichDuoi = 0;
            int KhoangChong = 0;

    
            for (int dem = 1; dem <= 4 && dongHT >= 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else if (matrix[dongHT - dem, cotHT].SoHuu.Equals(players[0]))
                {
                    SoQuanDichTren++;
                    break;
                }
                else KhoangChong++;
            }
            
            for (int dem = 1; dem <= 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5; dem++)
            {
                if (matrix[dongHT + dem, cotHT].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT + dem, cotHT].SoHuu.Equals(players[0]))
                {
                    SoQuanDichDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            
            if (SoQuanDichTren > 0 && SoQuanDichDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichTren + SoQuanDichDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }
        private int duyetTCNgang(int dongHT, int cotHT)

        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichPhai = 0;
            int SoQuanDichTrai = 0;
            int KhoangTrong = 0;

            
            for (int dem = 1; dem <= 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5; dem++)
            {

                if (matrix[dongHT, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangTrong++;
                }
                else
                    if (matrix[dongHT, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichPhai++;
                    break;
                }
                else KhoangTrong++;
            }
           
            for (int dem = 1; dem <= 4 && cotHT > 4; dem++)
            {
                if (matrix[dongHT, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangTrong++;

                }
                else
                    if (matrix[dongHT, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichTrai++;
                    break;
                }
                else KhoangTrong++;
            }
            
            if (SoQuanDichPhai > 0 && SoQuanDichTrai > 0 && KhoangTrong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichPhai + SoQuanDichTrai];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        private int duyetTCCheoChinh(int dongHT, int cotHT)
        {
            int DiemTanCong = 1;
            int SoQuanTa = 0;
            int SoQuanDichCheoTren = 0;
            int SoQuanDichCheoDuoi = 0;
            int KhoangChong = 0;

            
            for (int dem = 1; dem <= 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5 && dongHT < SoLieu.CHESS_BOARD_ROW - 5; dem++)
            {
                if (matrix[dongHT + dem, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT + dem, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichCheoTren++;
                    break;
                }
                else KhoangChong++;
            }
            
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT > 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT - dem, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichCheoDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            
            if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        private int duyetTCCheoPhu(int dongHT, int cotHT)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichCheoTren = 0;
            int SoQuanDichCheoDuoi = 0;
            int KhoangChong = 0;

            
            for (int dem = 1; dem <= 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5 && dongHT > 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT - dem, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichCheoTren++;
                    break;
                }
                else KhoangChong++;
            }
            
            for (int dem = 1; dem <= 4 && cotHT > 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5; dem++)
            {
                if (matrix[dongHT + dem, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (matrix[dongHT + dem, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    SoQuanDichCheoDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            
            if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }
        #endregion

        //các hàm duyệt phòng thủ
        #region Phòng Thủ
        private int duyetPNNgang(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangTrongPhai = 0;
            int KhoangTrongTrai = 0;
            bool ok = false;


            for (int dem = 1; dem <= 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5; dem++)
            {
                if (matrix[dongHT, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else if (matrix[dongHT, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangTrongPhai++;
                }
            }

            if (SoQuanDich == 3 && KhoangTrongPhai == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;

            for (int dem = 1; dem <= 4 && cotHT > 4; dem++)
            {
                if (matrix[dongHT, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else if (matrix[dongHT, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangTrongTrai++;
                }
            }

            if (SoQuanDich == 3 && KhoangTrongTrai == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangTrongTrai + KhoangTrongPhai + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        private int duyetPNDoc(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT > 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;

                }
                else
                    if (matrix[dongHT - dem, cotHT].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;
            //xuống
            for (int dem = 1; dem <= 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5; dem++)
            {
                //gặp quân địch
                if (matrix[dongHT + dem, cotHT].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT + dem, cotHT].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];
            return DiemPhongNgu;
        }
        private int duyetPNCheoChinh(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5; dem++)
            {
                if (matrix[dongHT + dem, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else if (matrix[dongHT + dem, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;
            //xuống
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT > 4; dem++)
            {
                if (matrix[dongHT - dem, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT - dem, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaTrai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        private int duyetPNCheoPhu(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT < SoLieu.CHESS_BOARD_COLUMN - 5; dem++)
            {

                if (matrix[dongHT - dem, cotHT + dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT - dem, cotHT + dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }


            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;

            //xuống
            for (int dem = 1; dem <= 4 && dongHT < SoLieu.CHESS_BOARD_ROW - 5 && cotHT > 4; dem++)
            {
                if (matrix[dongHT + dem, cotHT - dem].SoHuu.Equals(players[0]))
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (matrix[dongHT + dem, cotHT - dem].SoHuu.Equals(players[1]))
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }
        #endregion

        //các hàm phục vụ thuật toán alpha-beta pruning
        #region Bổ sung Cắt tỉa Alpha-Beta
        private bool CatTia(Oco oCo)
        {
            if (catTiaNgang(oCo) && catTiaDoc(oCo) && catTiaCheoChinh(oCo) && catTiaCheoPhu(oCo))
            {
                return true;
            }
            return false;
        }
        private bool catTiaDoc(Oco oCo)
        {
            if (oCo.soHang <= SoLieu.CHESS_BOARD_ROW - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang + i, oCo.soCot].SoHuu.Mark != "")
                        return false;

           
            if (oCo.soHang >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang - i, oCo.soCot].SoHuu.Mark != "")
                        return false;


            return true;
        }
        private bool catTiaCheoPhu(Oco oCo)
        {
            
            if (oCo.soHang <= SoLieu.CHESS_BOARD_ROW - 5 && oCo.soCot <= SoLieu.CHESS_BOARD_COLUMN - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang + i, oCo.soCot + i].SoHuu.Mark != "")
                        return false;

            
            if (oCo.soCot >= 4 && oCo.soHang >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang - i, oCo.soCot - i].SoHuu.Mark != "")
                        return false;

            
            return true;
        }

        private bool catTiaCheoChinh(Oco oCo)
        {
            
            if (oCo.soHang <= SoLieu.CHESS_BOARD_ROW - 5 && oCo.soCot >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang + i, oCo.soCot - i].SoHuu.Mark != "")
                        return false;

            
            if (oCo.soCot <= SoLieu.CHESS_BOARD_COLUMN - 5 && oCo.soHang >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang - i, oCo.soCot + i].SoHuu.Mark != "")
                        return false;

            
            return true;
        }

       

        private bool catTiaNgang(Oco oCo)
        {
            //duyệt phải
            if (oCo.soCot <= SoLieu.CHESS_BOARD_COLUMN - 5)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang, oCo.soCot + i].SoHuu.Mark != "")
                        return false;
            //duyệt trái
            if (oCo.soCot >= 4)
                for (int i = 1; i <= 4; i++)
                    if (matrix[oCo.soHang, oCo.soCot - i].SoHuu.Mark != "")
                        return false;
            return true;
        }

        public void MayQuyetDinhDanh(int i, int j)
        {
            string tag = string.Format("{0};{1}", i, j);
            Console.WriteLine(tag);
            foreach (Button control in pnl_BanCo.Controls)
            {
                if (control.Tag.Equals(tag))
                {
                    control.PerformClick();
                    break;
                }
            }
        }
        private void MayDanh()
        {
            int diemMax = 0;
            int diemPhongNgu = 0;
            int diemTanCong = 0;
            int imax = 0;
            int jmax = 0;

            //biến tạm chỉ để in ra màn hình kiểm tra điểm
            int tempTC = 0, tempPN = 0;

            if (soNutDaDanh == 0)
            {
                MayQuyetDinhDanh(new Random().Next(5, 10), new Random().Next(7, 12));
                return;
            }
            //tính giờ
            Stopwatch st = new Stopwatch();
            st.Reset();
            st.Start();
            //giải thuật minimax
            for (int i = 0; i < SoLieu.CHESS_BOARD_ROW; i++)
            {
                for (int j = 0; j < SoLieu.CHESS_BOARD_COLUMN; j++)
                {
                    if (matrix[i, j].SoHuu.Mark == "xxx" && !CatTia(matrix[i, j]))
                    {
                        int diemTam;
                        diemTanCong = duyetTCNgang(i, j) + duyetTCDoc(i, j) + duyetTCCheoChinh(i, j) + duyetTCCheoPhu(i, j);

                        diemPhongNgu = duyetPNNgang(i, j) + duyetPNDoc(i, j) + duyetPNCheoChinh(i, j) + duyetPNCheoPhu(i, j);
                        if (diemPhongNgu > diemTanCong)
                        {
                            diemTam = diemPhongNgu;
                        }
                        else
                        {
                            diemTam = diemTanCong;
                        }

                        if (diemMax < diemTam)
                        {
                            diemMax = diemTam;
                            imax = i;
                            jmax = j;


                            tempTC = diemTanCong;
                            tempPN = diemPhongNgu;
                        }
                    }
                }

            }
            st.Stop();

            MayQuyetDinhDanh(imax, jmax);

        }
        #endregion

        #endregion

    }
}
