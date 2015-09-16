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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AssignVehicleCommand = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ApprovePayoutCommand = new System.Windows.Forms.TabPage();
            this.ApprovePayoutButton = new System.Windows.Forms.Button();
            this.RejectPayoutCommand = new System.Windows.Forms.TabPage();
            this.CloseClaimCommand = new System.Windows.Forms.TabPage();
            this.ReopenClaimCommand = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.policyNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleMakeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleVinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RejectPayout = new System.Windows.Forms.Button();
            this.CloseClaim = new System.Windows.Forms.Button();
            this.ReopenClaim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.AssignVehicleCommand.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ApprovePayoutCommand.SuspendLayout();
            this.RejectPayoutCommand.SuspendLayout();
            this.CloseClaimCommand.SuspendLayout();
            this.ReopenClaimCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(508, 461);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Application.ViewModels.ClaimView);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.AssignVehicleCommand);
            this.tabControl1.Controls.Add(this.ApprovePayoutCommand);
            this.tabControl1.Controls.Add(this.RejectPayoutCommand);
            this.tabControl1.Controls.Add(this.CloseClaimCommand);
            this.tabControl1.Controls.Add(this.ReopenClaimCommand);
            this.tabControl1.Location = new System.Drawing.Point(13, 426);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(508, 130);
            this.tabControl1.TabIndex = 1;
            // 
            // AssignVehicleCommand
            // 
            this.AssignVehicleCommand.Controls.Add(this.button1);
            this.AssignVehicleCommand.Controls.Add(this.tableLayoutPanel1);
            this.AssignVehicleCommand.Location = new System.Drawing.Point(4, 25);
            this.AssignVehicleCommand.Name = "AssignVehicleCommand";
            this.AssignVehicleCommand.Size = new System.Drawing.Size(500, 101);
            this.AssignVehicleCommand.TabIndex = 0;
            this.AssignVehicleCommand.Text = "Assign Vehicle";
            this.AssignVehicleCommand.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.41176F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.58823F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "VIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Model";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(161, 17);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(152, 22);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(319, 17);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(77, 22);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(402, 17);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(89, 22);
            this.textBox4.TabIndex = 3;
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
            this.ApprovePayoutCommand.Size = new System.Drawing.Size(500, 101);
            this.ApprovePayoutCommand.TabIndex = 1;
            this.ApprovePayoutCommand.Text = "Approve Payout";
            this.ApprovePayoutCommand.UseVisualStyleBackColor = true;
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
            this.RejectPayoutCommand.Size = new System.Drawing.Size(500, 101);
            this.RejectPayoutCommand.TabIndex = 2;
            this.RejectPayoutCommand.Text = "Reject Payout";
            this.RejectPayoutCommand.UseVisualStyleBackColor = true;
            // 
            // CloseClaimCommand
            // 
            this.CloseClaimCommand.Controls.Add(this.CloseClaim);
            this.CloseClaimCommand.Location = new System.Drawing.Point(4, 25);
            this.CloseClaimCommand.Name = "CloseClaimCommand";
            this.CloseClaimCommand.Size = new System.Drawing.Size(500, 101);
            this.CloseClaimCommand.TabIndex = 3;
            this.CloseClaimCommand.Text = "Close Claim";
            this.CloseClaimCommand.UseVisualStyleBackColor = true;
            // 
            // ReopenClaimCommand
            // 
            this.ReopenClaimCommand.Controls.Add(this.ReopenClaim);
            this.ReopenClaimCommand.Location = new System.Drawing.Point(4, 25);
            this.ReopenClaimCommand.Name = "ReopenClaimCommand";
            this.ReopenClaimCommand.Size = new System.Drawing.Size(500, 101);
            this.ReopenClaimCommand.TabIndex = 4;
            this.ReopenClaimCommand.Text = "Reopen Claim";
            this.ReopenClaimCommand.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 563);
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
            this.RejectPayoutCommand.ResumeLayout(false);
            this.CloseClaimCommand.ResumeLayout(false);
            this.ReopenClaimCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AssignVehicleCommand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
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
    }
}

