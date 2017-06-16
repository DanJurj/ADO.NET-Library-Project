namespace Biblioteca.Presentation_Layer
{
    partial class ChangePermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePermissions));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_user = new System.Windows.Forms.DataGridView();
            this.btn_add1 = new System.Windows.Forms.Button();
            this.btn_add2 = new System.Windows.Forms.Button();
            this.btn_add3 = new System.Windows.Forms.Button();
            this.btn_add4 = new System.Windows.Forms.Button();
            this.btn_add0 = new System.Windows.Forms.Button();
            this.btn_rem0 = new System.Windows.Forms.Button();
            this.btn_rem4 = new System.Windows.Forms.Button();
            this.btn_rem3 = new System.Windows.Forms.Button();
            this.btn_rem2 = new System.Windows.Forms.Button();
            this.btn_rem1 = new System.Windows.Forms.Button();
            this.dgv_permissions = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_delUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permissions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(350, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Permissions:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(82, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Users:";
            // 
            // dgv_user
            // 
            this.dgv_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_user.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_user.Location = new System.Drawing.Point(22, 74);
            this.dgv_user.Name = "dgv_user";
            this.dgv_user.ReadOnly = true;
            this.dgv_user.RowHeadersVisible = false;
            this.dgv_user.RowTemplate.Height = 24;
            this.dgv_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_user.Size = new System.Drawing.Size(221, 358);
            this.dgv_user.TabIndex = 12;
            this.dgv_user.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_user_CellMouseClick);
            // 
            // btn_add1
            // 
            this.btn_add1.Location = new System.Drawing.Point(618, 74);
            this.btn_add1.Name = "btn_add1";
            this.btn_add1.Size = new System.Drawing.Size(89, 52);
            this.btn_add1.TabIndex = 13;
            this.btn_add1.Text = "ADD \r\nRead";
            this.btn_add1.UseVisualStyleBackColor = true;
            this.btn_add1.Click += new System.EventHandler(this.btn_add1_Click);
            // 
            // btn_add2
            // 
            this.btn_add2.Location = new System.Drawing.Point(618, 146);
            this.btn_add2.Name = "btn_add2";
            this.btn_add2.Size = new System.Drawing.Size(89, 52);
            this.btn_add2.TabIndex = 14;
            this.btn_add2.Text = "ADD Update";
            this.btn_add2.UseVisualStyleBackColor = true;
            this.btn_add2.Click += new System.EventHandler(this.btn_add2_Click);
            // 
            // btn_add3
            // 
            this.btn_add3.Location = new System.Drawing.Point(618, 215);
            this.btn_add3.Name = "btn_add3";
            this.btn_add3.Size = new System.Drawing.Size(89, 52);
            this.btn_add3.TabIndex = 15;
            this.btn_add3.Text = "ADD Create";
            this.btn_add3.UseVisualStyleBackColor = true;
            this.btn_add3.Click += new System.EventHandler(this.btn_add3_Click);
            // 
            // btn_add4
            // 
            this.btn_add4.Location = new System.Drawing.Point(618, 288);
            this.btn_add4.Name = "btn_add4";
            this.btn_add4.Size = new System.Drawing.Size(89, 52);
            this.btn_add4.TabIndex = 16;
            this.btn_add4.Text = "ADD Delete";
            this.btn_add4.UseVisualStyleBackColor = true;
            this.btn_add4.Click += new System.EventHandler(this.btn_add4_Click);
            // 
            // btn_add0
            // 
            this.btn_add0.Location = new System.Drawing.Point(618, 360);
            this.btn_add0.Name = "btn_add0";
            this.btn_add0.Size = new System.Drawing.Size(89, 62);
            this.btn_add0.TabIndex = 17;
            this.btn_add0.Text = "ADD Modify Permissions";
            this.btn_add0.UseVisualStyleBackColor = true;
            this.btn_add0.Click += new System.EventHandler(this.btn_add0_Click);
            // 
            // btn_rem0
            // 
            this.btn_rem0.Location = new System.Drawing.Point(752, 360);
            this.btn_rem0.Name = "btn_rem0";
            this.btn_rem0.Size = new System.Drawing.Size(89, 62);
            this.btn_rem0.TabIndex = 22;
            this.btn_rem0.Text = "Remove Modify Permissions";
            this.btn_rem0.UseVisualStyleBackColor = true;
            this.btn_rem0.Click += new System.EventHandler(this.btn_rem0_Click);
            // 
            // btn_rem4
            // 
            this.btn_rem4.Location = new System.Drawing.Point(752, 288);
            this.btn_rem4.Name = "btn_rem4";
            this.btn_rem4.Size = new System.Drawing.Size(89, 52);
            this.btn_rem4.TabIndex = 21;
            this.btn_rem4.Text = "Remove Delete";
            this.btn_rem4.UseVisualStyleBackColor = true;
            this.btn_rem4.Click += new System.EventHandler(this.btn_rem4_Click);
            // 
            // btn_rem3
            // 
            this.btn_rem3.Location = new System.Drawing.Point(752, 215);
            this.btn_rem3.Name = "btn_rem3";
            this.btn_rem3.Size = new System.Drawing.Size(89, 52);
            this.btn_rem3.TabIndex = 20;
            this.btn_rem3.Text = "REMOVE Create";
            this.btn_rem3.UseVisualStyleBackColor = true;
            this.btn_rem3.Click += new System.EventHandler(this.btn_rem3_Click);
            // 
            // btn_rem2
            // 
            this.btn_rem2.Location = new System.Drawing.Point(752, 146);
            this.btn_rem2.Name = "btn_rem2";
            this.btn_rem2.Size = new System.Drawing.Size(89, 52);
            this.btn_rem2.TabIndex = 19;
            this.btn_rem2.Text = "REMOVE Update";
            this.btn_rem2.UseVisualStyleBackColor = true;
            this.btn_rem2.Click += new System.EventHandler(this.btn_rem2_Click);
            // 
            // btn_rem1
            // 
            this.btn_rem1.Location = new System.Drawing.Point(752, 74);
            this.btn_rem1.Name = "btn_rem1";
            this.btn_rem1.Size = new System.Drawing.Size(89, 52);
            this.btn_rem1.TabIndex = 18;
            this.btn_rem1.Text = "REMOVE Read";
            this.btn_rem1.UseVisualStyleBackColor = true;
            this.btn_rem1.Click += new System.EventHandler(this.btn_rem1_Click);
            // 
            // dgv_permissions
            // 
            this.dgv_permissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_permissions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_permissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_permissions.Location = new System.Drawing.Point(324, 74);
            this.dgv_permissions.Name = "dgv_permissions";
            this.dgv_permissions.ReadOnly = true;
            this.dgv_permissions.RowHeadersVisible = false;
            this.dgv_permissions.RowTemplate.Height = 24;
            this.dgv_permissions.Size = new System.Drawing.Size(206, 249);
            this.dgv_permissions.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(689, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Actions:";
            // 
            // btn_delUser
            // 
            this.btn_delUser.Location = new System.Drawing.Point(249, 380);
            this.btn_delUser.Name = "btn_delUser";
            this.btn_delUser.Size = new System.Drawing.Size(77, 52);
            this.btn_delUser.TabIndex = 25;
            this.btn_delUser.Text = "Delete\r\nUser";
            this.btn_delUser.UseVisualStyleBackColor = true;
            this.btn_delUser.Click += new System.EventHandler(this.btn_delUser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Only for Admin";
            // 
            // ChangePermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(885, 497);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_delUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_permissions);
            this.Controls.Add(this.btn_rem0);
            this.Controls.Add(this.btn_rem4);
            this.Controls.Add(this.btn_rem3);
            this.Controls.Add(this.btn_rem2);
            this.Controls.Add(this.btn_rem1);
            this.Controls.Add(this.btn_add0);
            this.Controls.Add(this.btn_add4);
            this.Controls.Add(this.btn_add3);
            this.Controls.Add(this.btn_add2);
            this.Controls.Add(this.btn_add1);
            this.Controls.Add(this.dgv_user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePermissions";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_user;
        private System.Windows.Forms.Button btn_add1;
        private System.Windows.Forms.Button btn_add2;
        private System.Windows.Forms.Button btn_add3;
        private System.Windows.Forms.Button btn_add4;
        private System.Windows.Forms.Button btn_add0;
        private System.Windows.Forms.Button btn_rem0;
        private System.Windows.Forms.Button btn_rem4;
        private System.Windows.Forms.Button btn_rem3;
        private System.Windows.Forms.Button btn_rem2;
        private System.Windows.Forms.Button btn_rem1;
        private System.Windows.Forms.DataGridView dgv_permissions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_delUser;
        private System.Windows.Forms.Label label4;
    }
}