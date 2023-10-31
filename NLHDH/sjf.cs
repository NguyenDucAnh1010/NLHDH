using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLHDH
{
    public partial class sjf : Form
    {
        public sjf()
        {
            InitializeComponent();

            // Xác định kiểu dữ liệu của cột là số
            dataGridView1.Columns["Column2"].ValueType = typeof(int);
            dataGridView1.Columns["Column3"].ValueType = typeof(int);

            // Tắt đường viền của các nút
            button2.FlatAppearance.BorderSize = 0;
        }

        // hàm chuyển đổi dữ liệu DataGridView sang DataTable
        public DataTable LayDuLieuTuDataGridView()
        {
            DataTable dataTable = new DataTable();

            // Tạo cột cho DataTable
            for (int i = 0; i < 3; i++)
            {
                dataTable.Columns.Add("Column" + (i + 1).ToString());
            }

            // Lấy dữ liệu từ DataGridView và thêm vào DataTable
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < 3; i++)
                {
                    dataRow[i] = row.Cells[i].Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        // biến lưu lại số lượng projects
        decimal n = 0;

        // hàm nhận dữ liệu từ form khác chuyển tới
        public void NhanDuLieuTuFormGoc(DataTable duLieu)
        {
            // Sử dụng dữ liệu nhận được từ Form gốc ở đây
            n = duLieu.Rows.Count; // Lấy số lượng dòng trong DataTable nhận được và gán cho biến n
            numericUpDown1.Value = n; // Thiết lập giá trị của numericUpDown1 bằng n

            dataGridView1.Rows.Clear(); // Xóa tất cả các dòng hiện tại trong dataGridView1

            for (int i = 0; i < n; i++)
            {
                // Thêm một hàng mới vào bảng
                dataGridView1.Rows.Add();

                // Thiết lập giá trị cho từng ô trong hàng

                // Giả sử cột "PID" đã được tạo trước đó
                dataGridView1.Rows[i].Cells["Column1"].Value = duLieu.Rows[i][0];
                // Giả sử cột "ArrivalTime" đã được tạo trước đó
                dataGridView1.Rows[i].Cells["Column2"].Value = duLieu.Rows[i][1];
                // Giả sử cột "BurstTime" đã được tạo trước đó
                dataGridView1.Rows[i].Cells["Column3"].Value = duLieu.Rows[i][2];
                // Giả sử cột "Turnaround" đã được tạo trước đó
                dataGridView1.Rows[i].Cells["Column5"].Value = 0;
                // Giả sử cột "Waiting" đã được tạo trước đó
                dataGridView1.Rows[i].Cells["Column6"].Value = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp fcfs
            fcfs form = new fcfs();

            // Gọi phương thức LayDuLieuTuDataGridView() để lấy dữ liệu từ DataGridView và gán vào một đối tượng DataTable có tên duLieuTuDataGridView
            DataTable duLieuTuDataGridView = LayDuLieuTuDataGridView();

            // Gọi phương thức NhanDuLieuTuFormGoc() trên đối tượng form và truyền vào đối số duLieuTuDataGridView, để chuyển dữ liệu từ form gốc sang form mới (fcfs)
            form.NhanDuLieuTuFormGoc(duLieuTuDataGridView);

            // Hiển thị form mới (fcfs) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form fcfs được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp rr
            rr form = new rr();

            // Gọi phương thức LayDuLieuTuDataGridView() để lấy dữ liệu từ DataGridView và gán vào một đối tượng DataTable có tên duLieuTuDataGridView
            DataTable duLieuTuDataGridView = LayDuLieuTuDataGridView();

            // Gọi phương thức NhanDuLieuTuFormGoc() trên đối tượng form và truyền vào đối số duLieuTuDataGridView, để chuyển dữ liệu từ form gốc sang form mới (rr)
            form.NhanDuLieuTuFormGoc(duLieuTuDataGridView);

            // Hiển thị form mới (rr) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form rr được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp sjf
            sjf form = new sjf();

            // Gọi phương thức LayDuLieuTuDataGridView() để lấy dữ liệu từ DataGridView và gán vào một đối tượng DataTable có tên duLieuTuDataGridView
            DataTable duLieuTuDataGridView = LayDuLieuTuDataGridView();

            // Gọi phương thức NhanDuLieuTuFormGoc() trên đối tượng form và truyền vào đối số duLieuTuDataGridView, để chuyển dữ liệu từ form gốc sang form mới (sjf)
            form.NhanDuLieuTuFormGoc(duLieuTuDataGridView);

            // Hiển thị form mới (sjf) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form sjf được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                // Nếu giá trị của biến n là 0, tức là chưa có hàng nào trong dataGridView1

                n = numericUpDown1.Value; // Gán giá trị của numericUpDown1 vào biến n

                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    // Thêm một hàng mới vào bảng
                    dataGridView1.Rows.Add();

                    // Thiết lập giá trị cho từng ô trong hàng

                    // Giả sử cột "PID" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;

                    // Giả sử cột "ArrivalTime" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column2"].Value = 0;

                    // Giả sử cột "BurstTime" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column3"].Value = 0;

                    // Giả sử cột "Turnaround" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column5"].Value = 0;

                    // Giả sử cột "Waiting" đã được tạo trước đó
                    dataGridView1.Rows[i].Cells["Column6"].Value = 0;
                }
            }
            else
            {
                // Nếu giá trị của biến n không phải là 0, tức là đã có hàng trong dataGridView1

                if (n < numericUpDown1.Value)
                {
                    // Nếu giá trị của biến n nhỏ hơn giá trị củanumericUpDown1.Value, tức là số hàng hiện tại ít hơn số hàng mới được yêu cầu

                    for (int i = Convert.ToInt32(n); i < numericUpDown1.Value; i++)
                    {
                        // Thêm một hàng mới vào bảng
                        dataGridView1.Rows.Add();

                        // Thiết lập giá trị cho từng ô trong hàng

                        // Giả sử cột "PID" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;

                        // Giả sử cột "ArrivalTime" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column2"].Value = 0;

                        // Giả sử cột "BurstTime" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column3"].Value = 0;

                        // Giả sử cột "Turnaround" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column5"].Value = 0;

                        // Giả sử cột "Waiting" đã được tạo trước đó
                        dataGridView1.Rows[i].Cells["Column6"].Value = 0;
                    }

                    n = numericUpDown1.Value; // Cập nhật giá trị của biến n
                }
                else if (n > numericUpDown1.Value)
                {
                    // Nếu giá trị của biến n lớn hơn giá trị của numericUpDown1.Value, tức là số hàng hiện tại lớn hơn số hàng mới được yêu cầu

                    for (int i = Convert.ToInt32(n - 1); i > numericUpDown1.Value - 1; i--)
                    {
                        // Xóa hàng khỏi bảng
                        dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    }

                    n = numericUpDown1.Value; // Cập nhật giá trị của biến n
                }
            }
        }

        // Hàm thực hiện thuật toán sjf
        private void button3_Click(object sender, EventArgs e)
        {
            for (int time = 0; true; time++)
            {
                int min = 10000; // Khởi tạo giá trị nhỏ nhất cho burst time
                int i = -1; // Khởi tạo giá trị index của quá trình có burst time nhỏ nhất

                // Tìm quá trình có burst time nhỏ nhất và thỏa mãn các điều kiện
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Column5"].Value) == 0
                        && Convert.ToInt32(row.Cells["Column2"].Value) <= time
                        && Convert.ToInt32(row.Cells["Column3"].Value) < min)
                    {
                        min = Convert.ToInt32(row.Cells["Column3"].Value);
                        i = Convert.ToInt32(row.Cells["Column1"].Value) - 1;
                    }
                }

                // Nếu tìm thấy quá trình phù hợp
                if (i != -1)
                {
                    // Cập nhật thời gian chờ và thời gian lưu lại hệ thống cho quá trình đó
                    dataGridView1.Rows[i].Cells["Column6"].Value = time
                        - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value);

                    dataGridView1.Rows[i].Cells["Column5"].Value = time
                        + Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value)
                        - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value);

                    // Cập nhật thời gian hiện tại đến cuối burst time của quá trình
                    time += Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value) - 1;
                }
                else
                {
                    break; // Nếu không tìm thấy quá trình phù hợp, thoát khỏi vòng lặp
                }
            }

            decimal avgTurnaroundTime = 0;
            decimal avgWaitingTime = 0;

            // Tính trung bình thời gian lưu lại hệ thống và thời gian chờ
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                avgTurnaroundTime += Convert.ToInt32(row.Cells["Column5"].Value);
                avgWaitingTime += Convert.ToInt32(row.Cells["Column6"].Value);
            }

            // Hiển thị kết quả trung bình trên giao diện
            avgta.Text = (avgTurnaroundTime / n).ToString();
            avgwt.Text = (avgWaitingTime / n).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide(); // Ẩn form hiện tại

            // Tạo một thể hiện mới của lớp srtn
            srtn form = new srtn();

            // Gọi phương thức LayDuLieuTuDataGridView() để lấy dữ liệu từ DataGridView và gán vào một đối tượng DataTable có tên duLieuTuDataGridView
            DataTable duLieuTuDataGridView = LayDuLieuTuDataGridView();

            // Gọi phương thức NhanDuLieuTuFormGoc() trên đối tượng form và truyền vào đối số duLieuTuDataGridView, để chuyển dữ liệu từ form gốc sang form mới (srtn)
            form.NhanDuLieuTuFormGoc(duLieuTuDataGridView);

            // Hiển thị form mới (srtn) dưới dạng hộp thoại chờ và ngăn chặn người dùng tương tác với form gốc cho đến khi form srtn được đóng
            form.ShowDialog();

            // Đặt kết quả của hộp thoại thành DialogResult.OK. Điều này cho biết rằng hộp thoại đã được đóng một cách thành công và trạng thái trả về là OK.
            DialogResult = DialogResult.OK;

            Close(); // Đóng form hiện tại
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Thoát khỏi ứng dụng
            Application.Exit();
        }
    }
}
