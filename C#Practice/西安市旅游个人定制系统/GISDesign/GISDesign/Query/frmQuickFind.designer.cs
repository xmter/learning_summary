namespace GISDesign.Query
{
    partial class frmQuickFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuickFind));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxBlurSearch = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLayers = new System.Windows.Forms.ComboBox();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonNewSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelResultNumber = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(306, 216);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.label7);
            this.tabPage.Controls.Add(this.checkBoxBlurSearch);
            this.tabPage.Controls.Add(this.label6);
            this.tabPage.Controls.Add(this.label5);
            this.tabPage.Controls.Add(this.label4);
            this.tabPage.Controls.Add(this.comboBoxField);
            this.tabPage.Controls.Add(this.textBoxKeyword);
            this.tabPage.Controls.Add(this.label3);
            this.tabPage.Controls.Add(this.label2);
            this.tabPage.Controls.Add(this.comboBoxLayers);
            this.tabPage.Location = new System.Drawing.Point(4, 22);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(298, 190);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "条件设置";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(8, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 35);
            this.label7.TabIndex = 10;
            this.label7.Text = "提示:获得查询结果后,通过双击结果列表中的项目,可以将地图定位到该元素并将其选中";
            // 
            // checkBoxBlurSearch
            // 
            this.checkBoxBlurSearch.AutoSize = true;
            this.checkBoxBlurSearch.Location = new System.Drawing.Point(187, 99);
            this.checkBoxBlurSearch.Name = "checkBoxBlurSearch";
            this.checkBoxBlurSearch.Size = new System.Drawing.Size(96, 16);
            this.checkBoxBlurSearch.TabIndex = 9;
            this.checkBoxBlurSearch.Text = "进行模糊查找";
            this.checkBoxBlurSearch.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "字段";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "的";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "图层";
            // 
            // comboBoxField
            // 
            this.comboBoxField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Location = new System.Drawing.Point(26, 56);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(169, 20);
            this.comboBoxField.TabIndex = 4;
            this.comboBoxField.SelectedIndexChanged += new System.EventHandler(this.comboBoxField_SelectedIndexChanged);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(17, 95);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(165, 21);
            this.textBoxKeyword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "中查找:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "在";
            // 
            // comboBoxLayers
            // 
            this.comboBoxLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayers.FormattingEnabled = true;
            this.comboBoxLayers.Location = new System.Drawing.Point(26, 19);
            this.comboBoxLayers.Name = "comboBoxLayers";
            this.comboBoxLayers.Size = new System.Drawing.Size(222, 20);
            this.comboBoxLayers.TabIndex = 0;
            this.comboBoxLayers.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayers_SelectedIndexChanged);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 12;
            this.listBoxResults.Location = new System.Drawing.Point(324, 52);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(123, 172);
            this.listBoxResults.TabIndex = 1;
            this.listBoxResults.SelectedIndexChanged += new System.EventHandler(this.listBoxResults_SelectedIndexChanged);
            this.listBoxResults.DoubleClick += new System.EventHandler(this.listBoxResults_DoubleClick);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(16, 230);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "查找";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonNewSearch
            // 
            this.buttonNewSearch.Enabled = false;
            this.buttonNewSearch.Location = new System.Drawing.Point(97, 230);
            this.buttonNewSearch.Name = "buttonNewSearch";
            this.buttonNewSearch.Size = new System.Drawing.Size(100, 23);
            this.buttonNewSearch.TabIndex = 3;
            this.buttonNewSearch.Text = "进行新的查找";
            this.buttonNewSearch.UseVisualStyleBackColor = true;
            this.buttonNewSearch.Click += new System.EventHandler(this.buttonNewSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "结果列表:";
            // 
            // labelResultNumber
            // 
            this.labelResultNumber.AutoSize = true;
            this.labelResultNumber.Location = new System.Drawing.Point(382, 34);
            this.labelResultNumber.Name = "labelResultNumber";
            this.labelResultNumber.Size = new System.Drawing.Size(41, 12);
            this.labelResultNumber.TabIndex = 5;
            this.labelResultNumber.Text = "共  项";
            // 
            // frmQuickFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 267);
            this.Controls.Add(this.labelResultNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNewSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuickFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快速查找";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuickFind_FormClosed);
            this.Load += new System.EventHandler(this.frmQuickFind_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonNewSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLayers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxBlurSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelResultNumber;
    }
}