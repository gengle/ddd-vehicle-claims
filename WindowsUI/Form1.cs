using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Messaging.Commands;
using Application.Services;
using Application.ViewModels;
using Domain;
using Infrastructure.Services;

namespace WindowsUI
{
    public partial class Form1 : Form
    {
        private readonly ClaimReader _claimReader;
        private readonly Application.Services.ICommandDispatcher _dispatcher;
        private readonly IWorkspace _workspace;

        private BindingList<ClaimView> _claims; 

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(ClaimReader claimReader, ICommandDispatcher dispatcher, IWorkspace workspace):this()
        {
            _claimReader = claimReader;
            _dispatcher = dispatcher;
            this._workspace = workspace;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _claims = new BindingList<ClaimView>(_claimReader.GetAll().ToList());
            bindingSource1.DataSource = _claims;

            //ataGridView1.DataSource = _claimReader.GetAll();
        }

        private void assignVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var item = bindingSource1.Current as ClaimView;
            var handlers = new Dictionary<string, Action>()
            {
                {"AssignVehicleCommand", () => tabControl1.TabPages.Add(AssignVehicleCommand)},
                {"ApprovePayoutCommand", () => tabControl1.TabPages.Add(ApprovePayoutCommand)},
                {"CloseClaimCommand", () => tabControl1.TabPages.Add(CloseClaimCommand)},
                //{"CreateClaimCommand", () => tabControl1.TabPages.Add(CreateClaimCommand)},
                {"RejectPayoutCommand", () => tabControl1.TabPages.Add(RejectPayoutCommand)},
                { "ReopenClaimCommand", () => tabControl1.TabPages.Add(ReopenClaimCommand)},
            };

            if (item != null)
            {
                tabControl1.TabPages.Clear();
                foreach (var tab in item.Routes)
                {
                    handlers[tab].Invoke();
                }

                //foreach (TabPage tab in tabControl1.TabPages.OfType<TabPage>().ToList())
                //{
                //    if (item.Routes.Contains(tab.Name))
                //        tabControl1.TabPages.Remove(tab);
                //    else
                //        handlers[tab.Name].Invoke();
                //    //tab.Visible = item.Routes.Contains(tab.Name);
                //}
            }
            tabControl1.Refresh();
            //e.RowIndex
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void Refresh(ClaimView view)
        {
            _claims[bindingSource1.Position] = _claimReader.GetById(new ClaimId(view.Id));
            dataGridView1.Refresh();
            _workspace.Commit();
        }

        private void ApprovePayoutButton_Click(object sender, EventArgs e)
        {
            var item = bindingSource1.Current as ClaimView;
            if (item != null)
            {
                _dispatcher.Dispatch(new ApprovePayoutCommand() { Id = item.Id.ToString(), Amount = numericUpDown1.Value});
                Refresh(item);
            }
        }

        private void RejectPayout_Click(object sender, EventArgs e)
        {
            var item = bindingSource1.Current as ClaimView;
            if (item != null)
            {
                _dispatcher.Dispatch(new RejectPayoutCommand() { Id = item.Id.ToString()});
                Refresh(item);
            }
        }

        private void CloseClaim_Click(object sender, EventArgs e)
        {
            var item = bindingSource1.Current as ClaimView;
            if (item != null)
            {
                _dispatcher.Dispatch(new CloseClaimCommand() { Id = item.Id.ToString() });
                Refresh(item);
            }
        }

        private void ReopenClaim_Click(object sender, EventArgs e)
        {
            var item = bindingSource1.Current as ClaimView;
            if (item != null)
            {
                _dispatcher.Dispatch(new ReopenClaimCommand() { Id = item.Id.ToString() });
                Refresh(item);
            }
        }
    }
}
