namespace UPNP_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnMSearch = new Button();
            treeView1 = new TreeView();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnMSearch);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1035, 83);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnMSearch
            // 
            btnMSearch.Location = new Point(15, 15);
            btnMSearch.Margin = new Padding(15);
            btnMSearch.Name = "btnMSearch";
            btnMSearch.Size = new Size(119, 52);
            btnMSearch.TabIndex = 0;
            btnMSearch.Text = "M-Search";
            btnMSearch.UseVisualStyleBackColor = true;
            btnMSearch.Click += btnMSearch_Click;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 83);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(1035, 467);
            treeView1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 550);
            Controls.Add(treeView1);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UPNP Client";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnMSearch;
        private TreeView treeView1;
    }
}