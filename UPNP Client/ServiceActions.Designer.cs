namespace UPNP_Client
{
    partial class ServiceActions
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            dataGridActions = new DataGridView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            dataGridTableState = new DataGridView();
            label2 = new Label();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridActions).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTableState).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(876, 59);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);
            label1.Margin = new Padding(10);
            label1.Name = "label1";
            label1.Size = new Size(83, 30);
            label1.TabIndex = 0;
            label1.Text = "Actions";
            // 
            // dataGridActions
            // 
            dataGridActions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridActions.Dock = DockStyle.Top;
            dataGridActions.Location = new Point(0, 59);
            dataGridActions.Name = "dataGridActions";
            dataGridActions.RowHeadersWidth = 51;
            dataGridActions.RowTemplate.Height = 29;
            dataGridActions.Size = new Size(876, 188);
            dataGridActions.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 247);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(876, 54);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // dataGridTableState
            // 
            dataGridTableState.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTableState.Dock = DockStyle.Fill;
            dataGridTableState.Location = new Point(0, 301);
            dataGridTableState.Name = "dataGridTableState";
            dataGridTableState.RowHeadersWidth = 51;
            dataGridTableState.RowTemplate.Height = 29;
            dataGridTableState.Size = new Size(876, 219);
            dataGridTableState.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 10);
            label2.Margin = new Padding(10);
            label2.Name = "label2";
            label2.Size = new Size(118, 30);
            label2.TabIndex = 1;
            label2.Text = "Table State";
            // 
            // ServiceActions
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 520);
            Controls.Add(dataGridTableState);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(dataGridActions);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 4, 4, 4);
            Name = "ServiceActions";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Service Actions";
            Load += ServiceActions_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridActions).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridTableState).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private DataGridView dataGridActions;
        private FlowLayoutPanel flowLayoutPanel2;
        private DataGridView dataGridTableState;
        private Label label2;
    }
}