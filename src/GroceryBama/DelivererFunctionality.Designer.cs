﻿namespace GroceryBama
{
    partial class DelivererFunctionality
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
            this.button_back = new System.Windows.Forms.Button();
            this.button_assignments = new System.Windows.Forms.Button();
            this.button_accountinfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(359, 386);
            this.button_back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(107, 49);
            this.button_back.TabIndex = 33;
            this.button_back.Text = "Back";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_assignments
            // 
            this.button_assignments.Location = new System.Drawing.Point(74, 92);
            this.button_assignments.Name = "button_assignments";
            this.button_assignments.Size = new System.Drawing.Size(136, 64);
            this.button_assignments.TabIndex = 32;
            this.button_assignments.Text = "Assignments";
            this.button_assignments.UseVisualStyleBackColor = true;
            this.button_assignments.Click += new System.EventHandler(this.button_assignments_Click);
            // 
            // button_accountinfo
            // 
            this.button_accountinfo.Location = new System.Drawing.Point(590, 92);
            this.button_accountinfo.Name = "button_accountinfo";
            this.button_accountinfo.Size = new System.Drawing.Size(136, 64);
            this.button_accountinfo.TabIndex = 31;
            this.button_accountinfo.Text = "Account Information";
            this.button_accountinfo.UseVisualStyleBackColor = true;
            this.button_accountinfo.Click += new System.EventHandler(this.button_accountinfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 32);
            this.label1.TabIndex = 28;
            this.label1.Text = "Deliverer Functionality";
            // 
            // DelivererFunctionality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_assignments);
            this.Controls.Add(this.button_accountinfo);
            this.Controls.Add(this.label1);
            this.Name = "DelivererFunctionality";
            this.Text = "DelivererFunctionality";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_assignments;
        private System.Windows.Forms.Button button_accountinfo;
        private System.Windows.Forms.Label label1;
    }
}