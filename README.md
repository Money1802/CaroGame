# CaroGame
Sử dụng ngôn ngữ C# 
Áp dụng giải thuật Minimax và Cắt tỉa cây

Ở trò chơi này, ngoài các chức năng mở nhạc, hủy ván, chơi lại thì trò chơi có 2 chế độ chơi chính:
Người đấu với người (2 người sẽ thay phiên cầm chuột để đi những nước đi của mình)
Người đấu với máy (Người chơi sẽ đánh và máy sẽ sử dụng giải thuật để đi các nước tấn công hoặc phòng thủ)

Về lý thuyết trong trò chơi:
  1. Minimax
A đại diện cho max, B đại diện cho min, Số điểm của A + B = 0. A và B thay phiên nhau ra các nước cờ của mình. Với lượt của A sẽ chọn các nước cờ có giá trị lớn hơn và ngược lại so với B.

  2. Cắt tỉa cây
Ở đây sử dụng nhằm mục đích tính toán được các trường hợp dư thừa nhằm loại bỏ ra khỏi quá trình tính điểm của máy trong các bước để có thể xử lý nhanh chóng và tiết kiệm dung lượng khi tính toán

1 số hình ảnh của game:

![image](https://github.com/Money1802/CaroGame/assets/92535502/ade3003e-bea9-44ae-932f-442a94e220f6)

Thay vì sử dụng cái button mặc định thì ở đây mình sử dụng lệnh để tự tạo 1 panel có ma trận có 18 cột 16 dòng và chưa các ô vuông có size 24
