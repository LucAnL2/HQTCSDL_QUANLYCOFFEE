using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCSDL.ActiveInForms
{
    //Class này định nghĩa các hoạt động trong form ví dụ: mở form con, tải usercontrol lên panel....
    public class Active
    {

        //Khai báo biến này để xác định form con nào hiện đang được hiển thị trên panel
        public static Form activeForm;

        //Hàm này dùng để mở form con lên panel đầu vào là tên form, "ref Form activeForm" và tên panel
        public void OpenChildForm(Form childForm, ref Form activeForm, Panel panel)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

    }
}
