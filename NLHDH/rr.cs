using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace NLHDH
{
    public partial class rr : Form
    {
        public rr()
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

        // Hàm thực hiện thuật toán rr
        private void button3_Click(object sender, EventArgs e)
        {
            int avgwt1 = 0, avgta1 = 0, flag = 0;

            // Khởi tạo mảng rt với kích thước bằng giá trị của biến n
            int[] rt = new int[Convert.ToInt32(n)];

            // Lấy giá trị từ ô "n" và lưu vào biến remain
            int remain = Convert.ToInt32(n);

            // Lấy giá trị từ ô "numericUpDown2.Value" và lưu vào biến ts
            int ts = Convert.ToInt32(numericUpDown2.Value);

            // Lấy giá trị từ cột "Column3" của từng hàng trong DataGridView và lưu vào mảng rt
            for (int i = 0; i < n; i++)
            {
                rt[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value);
            }

            // Vòng lặp để thực hiện thuật toán
            for (int time = 0, i = 0; remain != 0;)
            {
                // Nếu thời gian còn lại của quá trình i nhỏ hơn hoặc bằng ts và lớn hơn 0
                if (rt[i] <= ts && rt[i] > 0)
                {
                    time += rt[i]; // Cập nhật thời gian
                    rt[i] = 0; // Đặt thời gian còn lại của quá trình i thành 0
                    flag = 1;
                }
                // Nếu thời gian còn lại của quá trình i lớn hơn 0
                else if (rt[i] > 0)
                {
                    rt[i] -= ts; // Giảm thời gian còn lại của quá trình i đi ts
                    time += ts; // Cập nhật thời gian
                }

                // Nếu thời gian còn lại của quá trình i bằng 0 và đã xảy ra chạy xong (flag = 1)
                if (rt[i] == 0 && flag == 1)
                {
                    remain--; // Giảm số lượng quá trình còn lại
                              // Tính toán giá trị cho các cột trong DataGridView
                    dataGridView1.Rows[i].Cells["Column5"].Value = time - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value);
                    dataGridView1.Rows[i].Cells["Column6"].Value = time - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value) - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value);
                    avgwt1 += time - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value) - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column3"].Value);
                    avgta1 += time - Convert.ToInt32(dataGridView1.Rows[i].Cells["Column2"].Value);
                    flag = 0; // Đặt lại flag về 0
                }

                // Xác định quá trình kế tiếp để thực hiện
                if (i == n - 1)
                    i = 0;
                else if (Convert.ToInt32(dataGridView1.Rows[i + 1].Cells["Column2"].Value) <= time)
                    i++;
                else
                    i = 0;
            }

            // Tính toán và hiển thị kết quả trung bình
            avgta.Text = (avgta1 / n).ToString();
            avgwt.Text = (avgwt1 / n).ToString();
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
