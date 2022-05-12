namespace Simulator
{
    partial class MainForm
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
        [System.Obsolete]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RobotContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnDescending = new System.Windows.Forms.RadioButton();
            this.rbtnAscending = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxAlgorithm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetValue = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblSort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAbout = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayout.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // RobotContainer
            // 
            this.RobotContainer.BackColor = System.Drawing.SystemColors.Window;
            this.RobotContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RobotContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RobotContainer.Location = new System.Drawing.Point(3, 28);
            this.RobotContainer.Name = "RobotContainer";
            this.RobotContainer.Size = new System.Drawing.Size(1476, 586);
            this.RobotContainer.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1476, 230);
            this.panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPauseResume);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.btnStep);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbSpeed);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(925, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 200);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(222, 114);
            this.tbSpeed.Maximum = 2000;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(288, 56);
            this.tbSpeed.TabIndex = 4;
            this.tbSpeed.Value = 1200;
            this.tbSpeed.Scroll += new System.EventHandler(this.TbSpeed_Scroll);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(30, 60);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 90);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(350, 60);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(160, 35);
            this.btnStep.TabIndex = 2;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.BtnStep_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Speed";
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Location = new System.Drawing.Point(160, 60);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(160, 35);
            this.btnPauseResume.TabIndex = 1;
            this.btnPauseResume.Text = "Pause/Resume";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.BtnPauseResume_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboxAlgorithm);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rbtnAscending);
            this.groupBox2.Controls.Add(this.rbtnDescending);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(528, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // rbtnDescending
            // 
            this.rbtnDescending.AutoSize = true;
            this.rbtnDescending.Location = new System.Drawing.Point(206, 146);
            this.rbtnDescending.Name = "rbtnDescending";
            this.rbtnDescending.Size = new System.Drawing.Size(119, 24);
            this.rbtnDescending.TabIndex = 4;
            this.rbtnDescending.Text = "Descending";
            this.rbtnDescending.UseVisualStyleBackColor = true;
            // 
            // rbtnAscending
            // 
            this.rbtnAscending.AutoSize = true;
            this.rbtnAscending.Checked = true;
            this.rbtnAscending.Location = new System.Drawing.Point(55, 146);
            this.rbtnAscending.Name = "rbtnAscending";
            this.rbtnAscending.Size = new System.Drawing.Size(108, 24);
            this.rbtnAscending.TabIndex = 3;
            this.rbtnAscending.TabStop = true;
            this.rbtnAscending.Text = "Ascending";
            this.rbtnAscending.UseVisualStyleBackColor = true;
            this.rbtnAscending.CheckedChanged += new System.EventHandler(this.RbtnAscending_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sorting Algorithm";
            // 
            // cboxAlgorithm
            // 
            this.cboxAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxAlgorithm.FormattingEnabled = true;
            this.cboxAlgorithm.Items.AddRange(new object[] {
            "Bubble Sort",
            "Insertion Sort",
            "Merge Sort",
            "Selection Sort",
            "Shell Sort",
            "Quick Sort"});
            this.cboxAlgorithm.Location = new System.Drawing.Point(200, 40);
            this.cboxAlgorithm.Name = "cboxAlgorithm";
            this.cboxAlgorithm.Size = new System.Drawing.Size(150, 28);
            this.cboxAlgorithm.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sort Order";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRandom);
            this.groupBox1.Controls.Add(this.btnSetValue);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create";
            // 
            // btnSetValue
            // 
            this.btnSetValue.Location = new System.Drawing.Point(350, 115);
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(120, 35);
            this.btnSetValue.TabIndex = 2;
            this.btnSetValue.Text = "Set Value";
            this.btnSetValue.UseVisualStyleBackColor = true;
            this.btnSetValue.Click += new System.EventHandler(this.BtnSetValue_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(350, 60);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(120, 35);
            this.btnRandom.TabIndex = 1;
            this.btnRandom.Text = "Random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.BtnRandom_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(30, 40);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(290, 130);
            this.txtValue.TabIndex = 0;
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 1;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.panel1, 0, 2);
            this.tableLayout.Controls.Add(this.RobotContainer, 0, 1);
            this.tableLayout.Controls.Add(this.statusStrip, 0, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 3;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.930832F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.40211F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.54982F));
            this.tableLayout.Size = new System.Drawing.Size(1482, 853);
            this.tableLayout.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSort,
            this.toolStripStatusLabel1,
            this.lblAbout});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1482, 25);
            this.statusStrip.TabIndex = 0;
            // 
            // lblSort
            // 
            this.lblSort.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(0, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1442, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblAbout
            // 
            this.lblAbout.Image = global::Simulator.Properties.Resources.exclamation_blue;
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(20, 19);
            this.lblAbout.Click += new System.EventHandler(this.LblAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 853);
            this.Controls.Add(this.tableLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Algorithm Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetValue;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.RadioButton rbtnDescending;
        private System.Windows.Forms.RadioButton rbtnAscending;
        private System.Windows.Forms.Panel RobotContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.ToolStripStatusLabel lblSort;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblAbout;
        private System.Windows.Forms.ComboBox cboxAlgorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
    }
}
