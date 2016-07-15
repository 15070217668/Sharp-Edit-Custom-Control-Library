namespace secl
{
    partial class HotkeysEditorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cbModifiers = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cbKey = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cbAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.btResore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbModifiers,
            this.cbKey,
            this.cbAction});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.GridColor = System.Drawing.SystemColors.Control;
            this.dgv.Location = new System.Drawing.Point(4, 12);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(292, 281);
            this.dgv.TabIndex = 0;
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            // 
            // cbModifiers
            // 
            this.cbModifiers.DataPropertyName = "Modifiers";
            this.cbModifiers.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cbModifiers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbModifiers.HeaderText = "Modifiers";
            this.cbModifiers.Name = "cbModifiers";
            // 
            // cbKey
            // 
            this.cbKey.DataPropertyName = "Key";
            this.cbKey.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cbKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbKey.HeaderText = "Key";
            this.cbKey.Name = "cbKey";
            this.cbKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbKey.Width = 120;
            // 
            // cbAction
            // 
            this.cbAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cbAction.DataPropertyName = "Action";
            this.cbAction.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cbAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAction.HeaderText = "Action";
            this.cbAction.Name = "cbAction";
            // 
            // btAdd
            // 
            this.btAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btAdd.Font = new System.Drawing.Font("Open Sans", 8F);
            this.btAdd.Location = new System.Drawing.Point(302, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(91, 25);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btRemove.Font = new System.Drawing.Font("Open Sans", 8F);
            this.btRemove.Location = new System.Drawing.Point(302, 39);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(91, 25);
            this.btRemove.TabIndex = 2;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btCancel.Font = new System.Drawing.Font("Open Sans", 8F);
            this.btCancel.Location = new System.Drawing.Point(302, 120);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(91, 25);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btOk.Font = new System.Drawing.Font("Open Sans", 8F);
            this.btOk.Location = new System.Drawing.Point(302, 93);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(91, 25);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btResore
            // 
            this.btResore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btResore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btResore.Font = new System.Drawing.Font("Open Sans", 8F);
            this.btResore.Location = new System.Drawing.Point(302, 65);
            this.btResore.Name = "btResore";
            this.btResore.Size = new System.Drawing.Size(91, 25);
            this.btResore.TabIndex = 6;
            this.btResore.Text = "Restore default";
            this.btResore.UseVisualStyleBackColor = true;
            this.btResore.Click += new System.EventHandler(this.btResore_Click);
            // 
            // HotkeysEditorForm
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(408, 306);
            this.Controls.Add(this.btResore);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dgv);
            this.Font = new System.Drawing.Font("Open Sans", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeysEditorForm";
            this.ShowIcon = false;
            this.Text = "Hotkeys Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HotkeysEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.HotkeysEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btResore;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbModifiers;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbKey;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbAction;
    }
}