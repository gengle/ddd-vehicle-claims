namespace WindowsUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.policyNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleMakeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleVinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AssignVehicleCommand = new System.Windows.Forms.TabPage();
            this.assignVehicleExecute = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtVin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ApprovePayoutCommand = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ApprovePayoutButton = new System.Windows.Forms.Button();
            this.RejectPayoutCommand = new System.Windows.Forms.TabPage();
            this.RejectPayout = new System.Windows.Forms.Button();
            this.CloseClaimCommand = new System.Windows.Forms.TabPage();
            this.CloseClaim = new System.Windows.Forms.Button();
            this.ReopenClaimCommand = new System.Windows.Forms.TabPage();
            this.ReopenClaim = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdAddClaim = new System.Windows.Forms.Button();
            this.txtPolicyNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.AssignVehicleCommand.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ApprovePayoutCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.RejectPayoutCommand.SuspendLayout();
            this.CloseClaimCommand.SuspendLayout();
            this.ReopenClaimCommand.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.policyNoDataGridViewTextBoxColumn,
            this.claimNoDataGridViewTextBoxColumn,
            this.payoutDataGridViewTextBoxColumn,
            this.vehicleMakeDataGridViewTextBoxColumn,
            this.vehicleModelDataGridViewTextBoxColumn,
            this.vehicleYearDataGridViewTextBoxColumn,
            this.vehicleVinDataGridViewTextBoxColumn,
            this.claimStateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1015, 224);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // policyNoDataGridViewTextBoxColumn
            // 
            this.policyNoDataGridViewTextBoxColumn.DataPropertyName = "PolicyNo";
            this.policyNoDataGridViewTextBoxColumn.HeaderText = "PolicyNo";
            this.policyNoDataGridViewTextBoxColumn.Name = "policyNoDataGridViewTextBoxColumn";
            // 
            // claimNoDataGridViewTextBoxColumn
            // 
            this.claimNoDataGridViewTextBoxColumn.DataPropertyName = "ClaimNo";
            this.claimNoDataGridViewTextBoxColumn.HeaderText = "ClaimNo";
            this.claimNoDataGridViewTextBoxColumn.Name = "claimNoDataGridViewTextBoxColumn";
            // 
            // payoutDataGridViewTextBoxColumn
            // 
            this.payoutDataGridViewTextBoxColumn.DataPropertyName = "Payout";
            this.payoutDataGridViewTextBoxColumn.HeaderText = "Payout";
            this.payoutDataGridViewTextBoxColumn.Name = "payoutDataGridViewTextBoxColumn";
            // 
            // vehicleMakeDataGridViewTextBoxColumn
            // 
            this.vehicleMakeDataGridViewTextBoxColumn.DataPropertyName = "VehicleMake";
            this.vehicleMakeDataGridViewTextBoxColumn.HeaderText = "VehicleMake";
            this.vehicleMakeDataGridViewTextBoxColumn.Name = "vehicleMakeDataGridViewTextBoxColumn";
            // 
            // vehicleModelDataGridViewTextBoxColumn
            // 
            this.vehicleModelDataGridViewTextBoxColumn.DataPropertyName = "VehicleModel";
            this.vehicleModelDataGridViewTextBoxColumn.HeaderText = "VehicleModel";
            this.vehicleModelDataGridViewTextBoxColumn.Name = "vehicleModelDataGridViewTextBoxColumn";
            // 
            // vehicleYearDataGridViewTextBoxColumn
            // 
            this.vehicleYearDataGridViewTextBoxColumn.DataPropertyName = "VehicleYear";
            this.vehicleYearDataGridViewTextBoxColumn.HeaderText = "VehicleYear";
            this.vehicleYearDataGridViewTextBoxColumn.Name = "vehicleYearDataGridViewTextBoxColumn";
            // 
            // vehicleVinDataGridViewTextBoxColumn
            // 
            this.vehicleVinDataGridViewTextBoxColumn.DataPropertyName = "VehicleVin";
            this.vehicleVinDataGridViewTextBoxColumn.HeaderText = "VehicleVin";
            this.vehicleVinDataGridViewTextBoxColumn.Name = "vehicleVinDataGridViewTextBoxColumn";
            // 
            // claimStateDataGridViewTextBoxColumn
            // 
            this.claimStateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.claimStateDataGridViewTextBoxColumn.DataPropertyName = "ClaimState";
            this.claimStateDataGridViewTextBoxColumn.HeaderText = "ClaimState";
            this.claimStateDataGridViewTextBoxColumn.Name = "claimStateDataGridViewTextBoxColumn";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Application.ViewModels.ClaimView);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.AssignVehicleCommand);
            this.tabControl1.Controls.Add(this.ApprovePayoutCommand);
            this.tabControl1.Controls.Add(this.RejectPayoutCommand);
            this.tabControl1.Controls.Add(this.CloseClaimCommand);
            this.tabControl1.Controls.Add(this.ReopenClaimCommand);
            this.tabControl1.Location = new System.Drawing.Point(13, 334);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1015, 156);
            this.tabControl1.TabIndex = 1;
            // 
            // AssignVehicleCommand
            // 
            this.AssignVehicleCommand.Controls.Add(this.assignVehicleExecute);
            this.AssignVehicleCommand.Controls.Add(this.tableLayoutPanel1);
            this.AssignVehicleCommand.Location = new System.Drawing.Point(4, 25);
            this.AssignVehicleCommand.Name = "AssignVehicleCommand";
            this.AssignVehicleCommand.Size = new System.Drawing.Size(1007, 127);
            this.AssignVehicleCommand.TabIndex = 0;
            this.AssignVehicleCommand.Text = "Assign Vehicle";
            this.AssignVehicleCommand.UseVisualStyleBackColor = true;
            // 
            // assignVehicleExecute
            // 
            this.assignVehicleExecute.Location = new System.Drawing.Point(3, 63);
            this.assignVehicleExecute.Name = "assignVehicleExecute";
            this.assignVehicleExecute.Size = new System.Drawing.Size(75, 23);
            this.assignVehicleExecute.TabIndex = 1;
            this.assignVehicleExecute.Text = "Execute";
            this.assignVehicleExecute.UseVisualStyleBackColor = true;
            this.assignVehicleExecute.Click += new System.EventHandler(this.assignVehicleExecute_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMake, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtModel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtYear, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtVin, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.41176F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.58823F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(908, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "VIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(825, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Model";
            // 
            // txtMake
            // 
            this.txtMake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMake.Location = new System.Drawing.Point(3, 17);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(405, 22);
            this.txtMake.TabIndex = 0;
            // 
            // txtModel
            // 
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModel.Location = new System.Drawing.Point(414, 17);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(405, 22);
            this.txtModel.TabIndex = 1;
            // 
            // txtYear
            // 
            this.txtYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYear.Location = new System.Drawing.Point(825, 17);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(77, 22);
            this.txtYear.TabIndex = 2;
            // 
            // txtVin
            // 
            this.txtVin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVin.Location = new System.Drawing.Point(908, 17);
            this.txtVin.Name = "txtVin";
            this.txtVin.Size = new System.Drawing.Size(90, 22);
            this.txtVin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Make";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ApprovePayoutCommand
            // 
            this.ApprovePayoutCommand.Controls.Add(this.numericUpDown1);
            this.ApprovePayoutCommand.Controls.Add(this.label5);
            this.ApprovePayoutCommand.Controls.Add(this.ApprovePayoutButton);
            this.ApprovePayoutCommand.Location = new System.Drawing.Point(4, 25);
            this.ApprovePayoutCommand.Name = "ApprovePayoutCommand";
            this.ApprovePayoutCommand.Size = new System.Drawing.Size(1007, 101);
            this.ApprovePayoutCommand.TabIndex = 1;
            this.ApprovePayoutCommand.Text = "Approve Payout";
            this.ApprovePayoutCommand.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 25);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Amount to Pay";
            // 
            // ApprovePayoutButton
            // 
            this.ApprovePayoutButton.Location = new System.Drawing.Point(7, 75);
            this.ApprovePayoutButton.Name = "ApprovePayoutButton";
            this.ApprovePayoutButton.Size = new System.Drawing.Size(75, 23);
            this.ApprovePayoutButton.TabIndex = 0;
            this.ApprovePayoutButton.Text = "Execute";
            this.ApprovePayoutButton.UseVisualStyleBackColor = true;
            this.ApprovePayoutButton.Click += new System.EventHandler(this.ApprovePayoutButton_Click);
            // 
            // RejectPayoutCommand
            // 
            this.RejectPayoutCommand.Controls.Add(this.RejectPayout);
            this.RejectPayoutCommand.Location = new System.Drawing.Point(4, 25);
            this.RejectPayoutCommand.Name = "RejectPayoutCommand";
            this.RejectPayoutCommand.Size = new System.Drawing.Size(1007, 101);
            this.RejectPayoutCommand.TabIndex = 2;
            this.RejectPayoutCommand.Text = "Reject Payout";
            this.RejectPayoutCommand.UseVisualStyleBackColor = true;
            // 
            // RejectPayout
            // 
            this.RejectPayout.Location = new System.Drawing.Point(4, 16);
            this.RejectPayout.Name = "RejectPayout";
            this.RejectPayout.Size = new System.Drawing.Size(75, 23);
            this.RejectPayout.TabIndex = 0;
            this.RejectPayout.Text = "Reject";
            this.RejectPayout.UseVisualStyleBackColor = true;
            this.RejectPayout.Click += new System.EventHandler(this.RejectPayout_Click);
            // 
            // CloseClaimCommand
            // 
            this.CloseClaimCommand.Controls.Add(this.CloseClaim);
            this.CloseClaimCommand.Location = new System.Drawing.Point(4, 25);
            this.CloseClaimCommand.Name = "CloseClaimCommand";
            this.CloseClaimCommand.Size = new System.Drawing.Size(1007, 101);
            this.CloseClaimCommand.TabIndex = 3;
            this.CloseClaimCommand.Text = "Close Claim";
            this.CloseClaimCommand.UseVisualStyleBackColor = true;
            // 
            // CloseClaim
            // 
            this.CloseClaim.Location = new System.Drawing.Point(3, 13);
            this.CloseClaim.Name = "CloseClaim";
            this.CloseClaim.Size = new System.Drawing.Size(75, 23);
            this.CloseClaim.TabIndex = 1;
            this.CloseClaim.Text = "Close";
            this.CloseClaim.UseVisualStyleBackColor = true;
            this.CloseClaim.Click += new System.EventHandler(this.CloseClaim_Click);
            // 
            // ReopenClaimCommand
            // 
            this.ReopenClaimCommand.Controls.Add(this.ReopenClaim);
            this.ReopenClaimCommand.Location = new System.Drawing.Point(4, 25);
            this.ReopenClaimCommand.Name = "ReopenClaimCommand";
            this.ReopenClaimCommand.Size = new System.Drawing.Size(1007, 101);
            this.ReopenClaimCommand.TabIndex = 4;
            this.ReopenClaimCommand.Text = "Reopen Claim";
            this.ReopenClaimCommand.UseVisualStyleBackColor = true;
            // 
            // ReopenClaim
            // 
            this.ReopenClaim.Location = new System.Drawing.Point(3, 3);
            this.ReopenClaim.Name = "ReopenClaim";
            this.ReopenClaim.Size = new System.Drawing.Size(75, 23);
            this.ReopenClaim.TabIndex = 2;
            this.ReopenClaim.Text = "Open";
            this.ReopenClaim.UseVisualStyleBackColor = true;
            this.ReopenClaim.Click += new System.EventHandler(this.ReopenClaim_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdAddClaim);
            this.groupBox1.Controls.Add(this.txtPolicyNum);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(13, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 94);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Claim";
            // 
            // cmdAddClaim
            // 
            this.cmdAddClaim.Location = new System.Drawing.Point(108, 43);
            this.cmdAddClaim.Name = "cmdAddClaim";
            this.cmdAddClaim.Size = new System.Drawing.Size(75, 23);
            this.cmdAddClaim.TabIndex = 2;
            this.cmdAddClaim.Text = "Add";
            this.cmdAddClaim.UseVisualStyleBackColor = true;
            this.cmdAddClaim.Click += new System.EventHandler(this.cmdAddClaim_Click);
            // 
            // txtPolicyNum
            // 
            this.txtPolicyNum.Location = new System.Drawing.Point(10, 43);
            this.txtPolicyNum.Name = "txtPolicyNum";
            this.txtPolicyNum.Size = new System.Drawing.Size(91, 22);
            this.txtPolicyNum.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Policy#";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.AssignVehicleCommand.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ApprovePayoutCommand.ResumeLayout(false);
            this.ApprovePayoutCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.RejectPayoutCommand.ResumeLayout(false);
            this.CloseClaimCommand.ResumeLayout(false);
            this.ReopenClaimCommand.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AssignVehicleCommand;
        private System.Windows.Forms.Button assignVehicleExecute;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtVin;
        private System.Windows.Forms.TabPage ApprovePayoutCommand;
        private System.Windows.Forms.TabPage RejectPayoutCommand;
        private System.Windows.Forms.TabPage CloseClaimCommand;
        private System.Windows.Forms.TabPage ReopenClaimCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ApprovePayoutButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn policyNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn claimNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn payoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleMakeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleModelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleVinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn claimStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button RejectPayout;
        private System.Windows.Forms.Button CloseClaim;
        private System.Windows.Forms.Button ReopenClaim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdAddClaim;
        private System.Windows.Forms.TextBox txtPolicyNum;
        private System.Windows.Forms.Label label6;
    }
}

