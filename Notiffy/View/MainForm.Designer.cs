namespace Notiffy.View
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            richTextBoxNotification = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBoxNotification
            // 
            richTextBoxNotification.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxNotification.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            richTextBoxNotification.Location = new Point(12, 12);
            richTextBoxNotification.Name = "richTextBoxNotification";
            richTextBoxNotification.Size = new Size(776, 426);
            richTextBoxNotification.TabIndex = 0;
            richTextBoxNotification.Text = "";
            richTextBoxNotification.TextChanged += richTextBoxNotification_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBoxNotification);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Notiffy 2.0";
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBoxNotification;
    }
}