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
            _dispatcher = new ExceptionTrapDispatcher(dispatcher);
            this._workspace = workspace;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _claims = new BindingList<ClaimView>(_claimReader.GetAll().ToList());
            bindingSource1.DataSource = _claims;
        }

        protected ClaimView GetClaimView(int row)
        {
            return _claims[row];
        }

        void UpdateTabPages(ClaimView item)
        {
            if (item == null) return;
            var handlers = new Dictionary<string, Action>()
            {
                {"AssignVehicleCommand", () => tabControl1.TabPages.Add(AssignVehicleCommand)},
                {"ApprovePayoutCommand", () => tabControl1.TabPages.Add(ApprovePayoutCommand)},
                {"CloseClaimCommand", () => tabControl1.TabPages.Add(CloseClaimCommand)},
                {"RejectPayoutCommand", () => tabControl1.TabPages.Add(RejectPayoutCommand)},
                {"ReopenClaimCommand", () => tabControl1.TabPages.Add(ReopenClaimCommand)},
            };

            if (item != null)
            {
                tabControl1.TabPages.Clear();
                foreach (var tab in item.Routes)
                {
                    handlers[tab].Invoke();
                }
            }
            tabControl1.Refresh();
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var item = GetClaimView(e.RowIndex);
            UpdateTabPages(item);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void Refresh(ClaimView view)
        {
            var reloaded = _claimReader.GetById(new ClaimId(view.Id));
            _claims[bindingSource1.Position] = reloaded;
            dataGridView1.Refresh();
            UpdateTabPages(reloaded);
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

        private void assignVehicleExecute_Click(object sender, EventArgs e)
        {
            var item = bindingSource1.Current as ClaimView;
            if (item != null)
            {
                _dispatcher.Dispatch(new AssignVehicleCommand()
                {
                    Id = item.Id.ToString(),
                    Vehicle = new Vehicle().WithMake(txtMake.Text)
                            .WithModel(txtModel.Text)
                            .WithYear(txtYear.Text)
                            .WithVin(txtVin.Text)
                });
                Refresh(item);
                txtMake.Text = string.Empty;
                txtModel.Text = string.Empty;
                txtYear.Text = string.Empty;
                txtVin.Text = string.Empty;
            }
        }

        private void cmdAddClaim_Click(object sender, EventArgs e)
        {
            var id = ClaimId.NewId();
            _dispatcher.Dispatch(new CreateClaimCommand()
            {
                Id = id.ToString(),
                PolicyNo = txtPolicyNum.Text
            });
            _workspace.Commit();
            var newClaim = _claimReader.GetById(id);
            _claims.Add(newClaim);
            dataGridView1.Refresh();
            txtPolicyNum.Text = string.Empty;
        }
    }
}
