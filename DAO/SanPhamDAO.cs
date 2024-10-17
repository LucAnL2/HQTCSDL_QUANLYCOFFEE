using DemoCSDL.Connection;
using DemoCSDL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DemoCSDL.DAO
{
    public class SanPhamDAO
    {
        DBConnection db = new DBConnection();
        
        public DataTable LoadProduct()
        {
            string query = "select MaSP as [Mã SP], MaLoaiSP as [Mã loại SP], TenSP as [Tên SP], TinhTrang as [Tình trạng], Gia as [Giá bán], HinhAnh as [Hình ảnh], TenLoaiSP as [Tên loại SP] " +
                " from product_type";
            return db.Load(query);
        }

        public void DeleteProduct(SanPham sp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteProduct", db.sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số vào SqlCommand
                cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = sp.MaSP;

                // Mở kết nối nếu chưa mở
                if (db.sqlCon.State == ConnectionState.Closed)
                {
                    db.sqlCon.Open();
                }

                // Thực thi stored procedure
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối sẽ được đóng
                if (db.sqlCon.State == ConnectionState.Open)
                {
                    db.sqlCon.Close();
                }
            }
        }
        public void UpdateProDuct(SanPham sp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateProduct", db.sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số vào SqlCommand
                cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = sp.MaSP;
                cmd.Parameters.Add("@MaLoaiSP", SqlDbType.NVarChar, 20).Value = sp.MaLoaiSP;
                cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 200).Value = sp.TenSP;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar, 50).Value = sp.TinhTrang;
                cmd.Parameters.Add("@HinhAnh", SqlDbType.VarChar, 1000).Value = sp.HinhAnh;
                cmd.Parameters.Add("@Gia", SqlDbType.Decimal).Value = sp.Gia;

                // Mở kết nối nếu chưa mở
                if (db.sqlCon.State == ConnectionState.Closed)
                {
                    db.sqlCon.Open();
                }

                // Thực thi stored procedure
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thông tin sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối sẽ được đóng
                if (db.sqlCon.State == ConnectionState.Open)
                {
                    db.sqlCon.Close();
                }
            }
        }
        public void AddProduct(SanPham sp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddProduct", db.sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số vào SqlCommand
                cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = sp.MaSP;
                cmd.Parameters.Add("@MaLoaiSP", SqlDbType.NVarChar, 20).Value = sp.MaLoaiSP;
                cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 200).Value = sp.TenSP;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar, 50).Value = sp.TinhTrang;
                cmd.Parameters.Add("@HinhAnh", SqlDbType.VarChar, 1000).Value = sp.HinhAnh;
                cmd.Parameters.Add("@Gia", SqlDbType.Decimal).Value = sp.Gia;

                // Mở kết nối nếu chưa mở
                if (db.sqlCon.State == ConnectionState.Closed)
                {
                    db.sqlCon.Open();
                }

                // Thực thi stored procedure
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm sản phẩm thành công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối sẽ được đóng
                if (db.sqlCon.State == ConnectionState.Open)
                {
                    db.sqlCon.Close();
                }
            }
        }

        public DataTable getDSSanPhamByString(string str)
        {
            string fnName = "TimKiemSP";
            using (SqlCommand command = new SqlCommand("Select MaSP as [Mã SP], MaLoaiSP as [Mã loại SP], TenSP as [Tên SP], TinhTrang as [Tình trạng], Gia as [Giá bán], HinhAnh as [Hình ảnh], TenLoaiSP as [Tên loại SP] from " + fnName + " (@searchString)", db.sqlCon))
            {
                command.Parameters.Add("@searchString", SqlDbType.NChar).Value = str;
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
        }


    }
}
