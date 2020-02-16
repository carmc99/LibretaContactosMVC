using MVCExample.Controllers;
using MVCExample.Models;
using System;
using System.Windows.Forms;

namespace MVCExample.Views
{
    public partial class Home : Form, IView
    {
        ContactControllers contactControl;
        public Home()
        {
            InitializeComponent();
            CreateHeadersListView();
            contactControl = new ContactControllers();
        }
        /// <summary> 
        /// Evento al presionar el boton agregar contacto
        /// </summary>
        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (contactControl.create(new Contact
            {
                Name = txt_name.Text,
                LastName = txt_lastname.Text,
                Addres = txt_address.Text,
                Phone = txt_phone.Text
            }))
            {
                LoadData();
                ClearInput();
                System.Windows.Forms.MessageBox.Show("Contacto registrado exitosamente", "Informacion",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Oops, ocurrio un problema al crear el contacto, intente nuevamente", "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }

        }
        /// <summary> 
        /// Crea los encabezados del listview
        /// </summary>
        public void CreateHeadersListView()
        {
            ColumnHeader colHead;

            colHead = new ColumnHeader();
            colHead.Text = "Name";
            this.listView_contacts.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "LastName";
            this.listView_contacts.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Phone";
            this.listView_contacts.Columns.Add(colHead);

            colHead = new ColumnHeader();
            colHead.Text = "Addres";
            this.listView_contacts.Columns.Add(colHead);

            listView_contacts.View = View.Details;
        }
        /// <summary> 
        /// Carga los contactos de la lista contactos al listview
        /// </summary>
        public void LoadData()
        {
            ListViewItem lvi;
            ListViewItem.ListViewSubItem lvsi;
            foreach (var item in contactControl.Contacts())
            {
                lvi = new ListViewItem();
                lvi.Text = item.Name;
                lvi.Tag = item.Name;

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = item.LastName;
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = item.Phone;
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = item.Addres;
                lvi.SubItems.Add(lvsi);

                this.listView_contacts.Items.Add(lvi);
            }
        }
        /// <summary> 
        /// Evento al presionar el boton eliminar contacto
        /// </summary>
        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (listView_contacts.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in listView_contacts.SelectedItems)
                {
                    if (contactControl.delete(lvi.SubItems[2].Text))
                    {
                        listView_contacts.Items.Remove(lvi);
                        System.Windows.Forms.MessageBox.Show("Contacto eliminado exitosamente", "Informacion",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Oops, ocurrio un problema al eliminar el contacto, intente nuevamente", "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Seleccione el contacto a eliminar", "Informacion",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information,
               MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary> 
        /// Limpia los campos del formulario
        /// </summary>
        public void ClearInput()
        {
            txt_address.Text = "";
            txt_lastname.Text = "";
            txt_name.Text = "";
            txt_phone.Text = "";
        }
    }
}
