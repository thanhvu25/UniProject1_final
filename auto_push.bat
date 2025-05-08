@echo off
cd /d D:\DATA\2. DA\DA1\DA1

:: Kiểm tra trạng thái git
git status

:: Thêm tất cả các thay đổi vào git
git add .

:: Commit với thông điệp tự động
git commit -m "Auto commit"

:: Đẩy các thay đổi lên GitHub
git push origin master

:: Hiển thị thông báo khi hoàn tất
echo Đẩy lên GitHub hoàn tất!
pause