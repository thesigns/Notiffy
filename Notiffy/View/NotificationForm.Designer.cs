namespace Notiffy.View
{
    partial class NotificationForm
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
            buttonOK = new Button();
            labelMessage = new Label();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.BackColor = SystemColors.ButtonFace;
            buttonOK.Cursor = Cursors.Hand;
            buttonOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            buttonOK.ForeColor = SystemColors.ActiveCaptionText;
            buttonOK.Location = new Point(350, 350);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(100, 50);
            buttonOK.TabIndex = 0;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = false;
            buttonOK.Click += buttonOK_Click;
            // 
            // labelMessage
            // 
            labelMessage.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelMessage.Location = new Point(100, 100);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(600, 200);
            labelMessage.TabIndex = 2;
            labelMessage.Text = "Notification message";
            labelMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(800, 450);
            Controls.Add(labelMessage);
            Controls.Add(buttonOK);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NotificationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NotificationForm";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOK;
        private Label labelMessage;
    }
}