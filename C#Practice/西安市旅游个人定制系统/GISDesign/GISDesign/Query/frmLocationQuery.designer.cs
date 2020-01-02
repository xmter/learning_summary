namespace GISDesign.Query
{
    partial class frmLocationQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocationQuery));
            this.buttonCancel1 = new System.Windows.Forms.Button();
            this.label0 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxConditiaon = new System.Windows.Forms.GroupBox();
            this.labe2 = new System.Windows.Forms.Label();
            this.comboBoxConditionLayer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBuffer = new System.Windows.Forms.TextBox();
            this.checkBoxBuffer = new System.Windows.Forms.CheckBox();
            this.checkBoxUseSelectedOnly = new System.Windows.Forms.CheckBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSpatialRel = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBoxShowSelectedOnly = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkedListBoxFeaturesLayer1 = new System.Windows.Forms.CheckedListBox();
            this.checkBoxShowVectorOnly1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxZoomtoSelected = new System.Windows.Forms.CheckBox();
            this.groupBoxConditiaon.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel1
            // 
            this.buttonCancel1.Location = new System.Drawing.Point(298, 369);
            this.buttonCancel1.Name = "buttonCancel1";
            this.buttonCancel1.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel1.TabIndex = 59;
            this.buttonCancel1.Text = "取消";
            this.buttonCancel1.UseVisualStyleBackColor = true;
            this.buttonCancel1.Click += new System.EventHandler(this.buttonCancel1_Click);
            // 
            // label0
            // 
            this.label0.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label0.Location = new System.Drawing.Point(7, 14);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(366, 41);
            this.label0.TabIndex = 49;
            this.label0.Text = "　　通过位置查询，你能够从一个或多个图层中查询出满足你所指定的空间位置条件的元素。空间位置条件通常指的是待查询图层的元素与另一个图层元素之间的空间关系，比如相交，" +
                "相离，包含等等。";
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(217, 369);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 62;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxConditiaon
            // 
            this.groupBoxConditiaon.Controls.Add(this.labe2);
            this.groupBoxConditiaon.Controls.Add(this.comboBoxConditionLayer);
            this.groupBoxConditiaon.Controls.Add(this.label7);
            this.groupBoxConditiaon.Controls.Add(this.label6);
            this.groupBoxConditiaon.Controls.Add(this.textBoxBuffer);
            this.groupBoxConditiaon.Controls.Add(this.checkBoxBuffer);
            this.groupBoxConditiaon.Controls.Add(this.checkBoxUseSelectedOnly);
            this.groupBoxConditiaon.Controls.Add(this.labelDescription);
            this.groupBoxConditiaon.Controls.Add(this.label4);
            this.groupBoxConditiaon.Controls.Add(this.label3);
            this.groupBoxConditiaon.Controls.Add(this.comboBoxSpatialRel);
            this.groupBoxConditiaon.Location = new System.Drawing.Point(9, 146);
            this.groupBoxConditiaon.Name = "groupBoxConditiaon";
            this.groupBoxConditiaon.Size = new System.Drawing.Size(365, 213);
            this.groupBoxConditiaon.TabIndex = 58;
            this.groupBoxConditiaon.TabStop = false;
            this.groupBoxConditiaon.Text = "需要满足的空间条件";
            // 
            // labe2
            // 
            this.labe2.AutoSize = true;
            this.labe2.Location = new System.Drawing.Point(6, 42);
            this.labe2.Name = "labe2";
            this.labe2.Size = new System.Drawing.Size(59, 12);
            this.labe2.TabIndex = 12;
            this.labe2.Text = "条件图层:";
            // 
            // comboBoxConditionLayer
            // 
            this.comboBoxConditionLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConditionLayer.FormattingEnabled = true;
            this.comboBoxConditionLayer.Location = new System.Drawing.Point(71, 39);
            this.comboBoxConditionLayer.Name = "comboBoxConditionLayer";
            this.comboBoxConditionLayer.Size = new System.Drawing.Size(278, 20);
            this.comboBoxConditionLayer.TabIndex = 11;
            this.comboBoxConditionLayer.DropDown += new System.EventHandler(this.comboBoxConditionLayer_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "大小";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(353, 32);
            this.label6.TabIndex = 9;
            this.label6.Text = "(单位与“条件图层”的地图单位相同。输入负数(只对多边形有效)生成的缓冲区将凹向图形内部)";
            // 
            // textBoxBuffer
            // 
            this.textBoxBuffer.Enabled = false;
            this.textBoxBuffer.Location = new System.Drawing.Point(227, 155);
            this.textBoxBuffer.Name = "textBoxBuffer";
            this.textBoxBuffer.Size = new System.Drawing.Size(132, 21);
            this.textBoxBuffer.TabIndex = 8;
            this.textBoxBuffer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBuffer_KeyDown);
            // 
            // checkBoxBuffer
            // 
            this.checkBoxBuffer.AutoSize = true;
            this.checkBoxBuffer.Location = new System.Drawing.Point(6, 160);
            this.checkBoxBuffer.Name = "checkBoxBuffer";
            this.checkBoxBuffer.Size = new System.Drawing.Size(198, 16);
            this.checkBoxBuffer.TabIndex = 7;
            this.checkBoxBuffer.Text = "对\"条件图层\"的元素生成缓冲区:";
            this.checkBoxBuffer.UseVisualStyleBackColor = true;
            this.checkBoxBuffer.CheckedChanged += new System.EventHandler(this.checkBoxBuffer_CheckedChanged);
            // 
            // checkBoxUseSelectedOnly
            // 
            this.checkBoxUseSelectedOnly.AutoSize = true;
            this.checkBoxUseSelectedOnly.Location = new System.Drawing.Point(9, 20);
            this.checkBoxUseSelectedOnly.Name = "checkBoxUseSelectedOnly";
            this.checkBoxUseSelectedOnly.Size = new System.Drawing.Size(240, 16);
            this.checkBoxUseSelectedOnly.TabIndex = 6;
            this.checkBoxUseSelectedOnly.Text = "仅使用图上已被选中的元素作为条件图层";
            this.checkBoxUseSelectedOnly.UseVisualStyleBackColor = true;
            this.checkBoxUseSelectedOnly.CheckedChanged += new System.EventHandler(this.checkBoxUseSelectedOnly_CheckedChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.BackColor = System.Drawing.SystemColors.Control;
            this.labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDescription.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelDescription.Location = new System.Drawing.Point(6, 115);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(353, 36);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "请选择上面的空间条件以查看相应的描述";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "描述:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "需要满足的空间条件是:";
            // 
            // comboBoxSpatialRel
            // 
            this.comboBoxSpatialRel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpatialRel.FormattingEnabled = true;
            this.comboBoxSpatialRel.Items.AddRange(new object[] {
            "与 “条件图层” 相交 (Intersects)",
            "被 “条件图层” 包含 (Contains)",
            "包含“条件图层” (Within)",
            "与 “条件图层” 的边界接触 (Touches)"});
            this.comboBoxSpatialRel.Location = new System.Drawing.Point(6, 78);
            this.comboBoxSpatialRel.Name = "comboBoxSpatialRel";
            this.comboBoxSpatialRel.Size = new System.Drawing.Size(341, 20);
            this.comboBoxSpatialRel.TabIndex = 2;
            this.comboBoxSpatialRel.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpatialRel_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 369);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 61;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(298, 369);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 60;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "大小";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(7, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "(单位与“条件图层”的地图单位相同)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBoxShowSelectedOnly);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Location = new System.Drawing.Point(9, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 200);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "需要满足的空间条件";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "条件图层:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(278, 20);
            this.comboBox1.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(228, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 21);
            this.textBox1.TabIndex = 8;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 160);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(198, 16);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "对\"条件图层\"的元素生成缓冲区:";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowSelectedOnly
            // 
            this.checkBoxShowSelectedOnly.AutoSize = true;
            this.checkBoxShowSelectedOnly.Location = new System.Drawing.Point(10, 20);
            this.checkBoxShowSelectedOnly.Name = "checkBoxShowSelectedOnly";
            this.checkBoxShowSelectedOnly.Size = new System.Drawing.Size(168, 16);
            this.checkBoxShowSelectedOnly.TabIndex = 6;
            this.checkBoxShowSelectedOnly.Text = "仅使用图上已被选中的元素";
            this.checkBoxShowSelectedOnly.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(7, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(353, 36);
            this.label11.TabIndex = 5;
            this.label11.Text = "请选择上面的空间条件以查看相应的描述";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "描述:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "需要满足的空间条件是:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "与 “条件图层” 相交 (Intersects)",
            "被 “条件图层” 包含 (Contains)",
            "包含“条件图层” (Within)",
            "与 “条件图层” 的边界接触 (Touches)"});
            this.comboBox2.Location = new System.Drawing.Point(7, 78);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(341, 20);
            this.comboBox2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "在以下图层中查询:";
            // 
            // checkedListBoxFeaturesLayer1
            // 
            this.checkedListBoxFeaturesLayer1.CheckOnClick = true;
            this.checkedListBoxFeaturesLayer1.Enabled = false;
            this.checkedListBoxFeaturesLayer1.FormattingEnabled = true;
            this.checkedListBoxFeaturesLayer1.Location = new System.Drawing.Point(9, 72);
            this.checkedListBoxFeaturesLayer1.Name = "checkedListBoxFeaturesLayer1";
            this.checkedListBoxFeaturesLayer1.Size = new System.Drawing.Size(364, 68);
            this.checkedListBoxFeaturesLayer1.TabIndex = 53;
            // 
            // checkBoxShowVectorOnly1
            // 
            this.checkBoxShowVectorOnly1.AutoSize = true;
            this.checkBoxShowVectorOnly1.Checked = true;
            this.checkBoxShowVectorOnly1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowVectorOnly1.Enabled = false;
            this.checkBoxShowVectorOnly1.Location = new System.Drawing.Point(233, 54);
            this.checkBoxShowVectorOnly1.Name = "checkBoxShowVectorOnly1";
            this.checkBoxShowVectorOnly1.Size = new System.Drawing.Size(108, 16);
            this.checkBoxShowVectorOnly1.TabIndex = 55;
            this.checkBoxShowVectorOnly1.Text = "只显示矢量图层";
            this.checkBoxShowVectorOnly1.UseVisualStyleBackColor = true;
            this.checkBoxShowVectorOnly1.CheckedChanged += new System.EventHandler(this.checkBoxShowVectorOnly1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.Location = new System.Drawing.Point(7, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 41);
            this.label2.TabIndex = 50;
            this.label2.Text = "　　通过位置查询，你能够从一个或多个图层中查询出满足你所指定的空间位置条件的元素。空间位置条件通常指的是待查询图层的元素与另一个图层元素之间的空间关系，比如相交，" +
                "相离，包含等等。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 51;
            this.label1.Text = "在以下图层中查询:";
            // 
            // checkBoxZoomtoSelected
            // 
            this.checkBoxZoomtoSelected.AutoSize = true;
            this.checkBoxZoomtoSelected.Checked = true;
            this.checkBoxZoomtoSelected.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZoomtoSelected.Location = new System.Drawing.Point(15, 369);
            this.checkBoxZoomtoSelected.Name = "checkBoxZoomtoSelected";
            this.checkBoxZoomtoSelected.Size = new System.Drawing.Size(108, 16);
            this.checkBoxZoomtoSelected.TabIndex = 63;
            this.checkBoxZoomtoSelected.Text = "定位到查询结果";
            this.checkBoxZoomtoSelected.UseVisualStyleBackColor = true;
            // 
            // frmLocationQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 409);
            this.Controls.Add(this.checkBoxZoomtoSelected);
            this.Controls.Add(this.buttonCancel1);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxConditiaon);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkedListBoxFeaturesLayer1);
            this.Controls.Add(this.checkBoxShowVectorOnly1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLocationQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通过位置查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLocationQuery_FormClosed);
            this.Load += new System.EventHandler(this.frmLocationQuery_Load);
            this.groupBoxConditiaon.ResumeLayout(false);
            this.groupBoxConditiaon.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel1;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxConditiaon;
        private System.Windows.Forms.Label labe2;
        private System.Windows.Forms.ComboBox comboBoxConditionLayer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBuffer;
        private System.Windows.Forms.CheckBox checkBoxBuffer;
        private System.Windows.Forms.CheckBox checkBoxUseSelectedOnly;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSpatialRel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBoxShowSelectedOnly;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkedListBoxFeaturesLayer1;
        private System.Windows.Forms.CheckBox checkBoxShowVectorOnly1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxZoomtoSelected;
        //private System.Windows.Forms.CheckBox checkBoxShowVectorOnly;
        //private System.Windows.Forms.CheckedListBox checkedListBoxFeaturesLayer;


    }
}