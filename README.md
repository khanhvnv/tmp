#https://vietnix.vn/day-code-len-github/

#Example:
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
 }
 
 dotnet add package Microsoft.AspNetCore.OpenApi
 
 Tạo 1 repo trên git
Mở visual studio code -> source control -> clone -> trỏ đến 1 directory để clone về
Copy required code vào thư mục mới đó, trừ git nếu có
Quay lại visual studio code -> click add những file cần commit
-> .. -> commit & push

Quick setup — if you’ve done this kind of thing before
or	
https://github.com/khanhvnv/.NET-FinalAssignment.git
Get started by creating a new file or uploading an existing file. We recommend every repository include a README, LICENSE, and .gitignore.

…or create a new repository on the command line
echo "# .NET-FinalAssignment" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/khanhvnv/.NET-FinalAssignment.git
git push -u origin main
…or push an existing repository from the command line
git remote add origin https://github.com/khanhvnv/.NET-FinalAssignment.git
git branch -M main
git push -u origin main
