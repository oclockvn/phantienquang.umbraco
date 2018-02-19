# Đoạn code thú vị

### Ví dụ

<script src="https://gist.github.com/oclockvn/eab365465eb06319e22d.js"></script>


Hãy để ý dòng số 4 (dòng 14 hình dưới), và kết quả là:

![img/interesting-code.png](img/interesting-code.png)

Bạn đã bắt đầu thấy tò mò chưa? Tại sao có dòng số 4 mà đoạn code vẫn biên dịch và chạy như thường. Nếu xem xét kỹ thì sẽ hiểu ngay:

- http: đánh dấu 1 nhãn (label) trong c#, được dùng với lệnh goto.
- `//phantienquang.blogspot.com/` chắc hẳn là 1 đoạn comment vì nằm sau dấu `//`

### Giải thích

Để hiểu rõ hơn, mình thêm 1 dòng code như sau:

<script src="https://gist.github.com/oclockvn/1de4907b266a02b9438a.js"></script>

Tất nhiên, kết quả sẽ bị lược bỏ dòng 5 vì lệnh goto đã nhảy tới nhãn http:

![explain](img/curious-code-debug-3.png)