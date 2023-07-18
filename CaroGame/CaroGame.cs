using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaroGame.Properties;
using System.IO;

namespace CaroGame
{
    public partial class CaroGame : Form
    {
        private GameControl game_Control;
        public bool computerMode = false;
        private bool playmusic = true;
        public CaroGame()
        {
            InitializeComponent();
            game_Control = new GameControl(this, pnl_BanCo);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CaroGame_Load(object sender, EventArgs e)
        {
            PlayMusic.Instance.OpenMediaFile(@"..\..\Data\YieArKungFu-DangCapNhat_3cjcw.mp3");
            PlayMusic.Instance.PlayMediaFile(true);
            btn_HuyVan.Enabled = false;
            btn_ChoiLai.Enabled = false;
        }
        #region Cài đặt menustrip
        private void càiĐặtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bậtTắtNhạcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playmusic == true)
            {
                PlayMusic.Instance.ClosePlayer();
                playmusic = false;
            }
            else
            {
                PlayMusic.Instance.OpenMediaFile(@"..\..\Data\YieArKungFu-DangCapNhat_3cjcw.mp3");
                PlayMusic.Instance.PlayMediaFile(true);
                playmusic = true;
            }
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là bài báo cáo cuối môn Trí tuệ Nhân Tạo\n Được thực hiện bởi\n - Đỗ Thị Ngọc Tuyền\n - Lưu Quốc Trung", "About Me", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void luậtChơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("- Hai người chơi quyết định quân đi là X hoặc O và quyết định người đi trước .\n- Người chơi đầu tiên đánh dấu vị trí đặt quân của mình lên các ô còn trống trên bàn cờ.\n- Tiếp đến là lượt chơi của người thứ hai với cách đi tương tự.\n- Người chơi không được phép đánh dấu vào ô đã có đánh dấu trước đó.\n- Người thắng cuộc là người đầu tiên có được một chuỗi liên tục các ô gồm 5 quân hàng ngang, hoặc dọc, hoặc chéo.","Luật chơi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void menu_CaiDat_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        #endregion

        #region Khai báo radio X và O
        public RadioButton getRadioButonX()
        {
            return radioX;
        }
        public RadioButton getRadioButonO()
        {
            return radioO;
        }
        #endregion

        #region Chọn chế độ
        private void btn_PvP_Click(object sender, EventArgs e)
        {
            computerMode = false;
            game_Control.VeBanCo(computerMode);

            groupBox1.Enabled = false;
            btn_PvM.Enabled = false;

            btn_HuyVan.Enabled = true;
            btn_ChoiLai.Enabled = true;
        }
        private void btn_PvM_Click(object sender, EventArgs e)
        {
            computerMode = true;
            game_Control.VeBanCo(computerMode);

            groupBox1.Enabled = false;
            btn_PvP.Enabled = false;
            btn_ChoiLai.Enabled = true;
            btn_HuyVan.Enabled = true;
        }
        #endregion
        

        private void btn_HuyVan_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy ván?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                game_Control.huyVan();

                groupBox1.Enabled = true;
                btn_PvP.Enabled = true;
                btn_PvM.Enabled = true;

                btn_HuyVan.Enabled = false;
                btn_ChoiLai.Enabled = false;

            }
        }

        private void btn_ChoiLai_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn chơi lại?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                game_Control.huyVan();
                game_Control.VeBanCo(computerMode);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
