
namespace messForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.sendMsgButton = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.messagePanel = new System.Windows.Forms.TextBox();
            this.clientName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sendMsgButton
            // 
            this.sendMsgButton.Location = new System.Drawing.Point(642, 301);
            this.sendMsgButton.Name = "sendMsgButton";
            this.sendMsgButton.Size = new System.Drawing.Size(132, 66);
            this.sendMsgButton.TabIndex = 0;
            this.sendMsgButton.Text = "Отправить сообщение";
            this.sendMsgButton.UseVisualStyleBackColor = true;
            this.sendMsgButton.Click += new System.EventHandler(this.sendMsgButton_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(642, 30);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(132, 44);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Подключиться";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.Location = new System.Drawing.Point(58, 85);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(542, 186);
            this.listBoxMessages.TabIndex = 2;
            // 
            // messagePanel
            // 
            this.messagePanel.Location = new System.Drawing.Point(58, 301);
            this.messagePanel.Multiline = true;
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(542, 66);
            this.messagePanel.TabIndex = 3;
            this.messagePanel.TextChanged += new System.EventHandler(this.messagePanel_TextChanged);
            // 
            // clientName
            // 
            this.clientName.Location = new System.Drawing.Point(470, 30);
            this.clientName.Multiline = true;
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(130, 44);
            this.clientName.TabIndex = 4;
            this.clientName.TextChanged += new System.EventHandler(this.clientName_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clientName);
            this.Controls.Add(this.messagePanel);
            this.Controls.Add(this.listBoxMessages);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.sendMsgButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendMsgButton;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ListBox listBoxMessages;
        private System.Windows.Forms.TextBox messagePanel;
        private System.Windows.Forms.TextBox clientName;
    }
}

