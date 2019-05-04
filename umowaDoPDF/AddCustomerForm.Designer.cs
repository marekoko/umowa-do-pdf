namespace umowaDoPDF
{
    partial class AddCustomerForm
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
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.tIDCard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tPesel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tStreet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tZipCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tCity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tSubjectOfAgreemnt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tPurchasePriceInWords = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudPurchasePrice = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudBuyoutPrice = new System.Windows.Forms.NumericUpDown();
            this.tBuyoutPriceInWords = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.bGeneratePDF = new System.Windows.Forms.Button();
            this.bSaveData = new System.Windows.Forms.Button();
            this.bSaveClient = new System.Windows.Forms.Button();
            this.cBoxClientsList = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.bChooseClientFromCBox = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuyoutPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(54, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(75, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Od:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Do:";
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(54, 38);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(75, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Klient:";
            // 
            // tName
            // 
            this.tName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tName.Location = new System.Drawing.Point(54, 67);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(246, 20);
            this.tName.TabIndex = 5;
            this.tName.Text = "-- Imię i Nazwisko --";
            this.tName.Enter += new System.EventHandler(this.TName_Enter);
            this.tName.Leave += new System.EventHandler(this.TName_Leave);
            // 
            // tIDCard
            // 
            this.tIDCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tIDCard.Location = new System.Drawing.Point(98, 143);
            this.tIDCard.Name = "tIDCard";
            this.tIDCard.Size = new System.Drawing.Size(442, 20);
            this.tIDCard.TabIndex = 17;
            this.tIDCard.Text = "-- Seria i Nr Dowodu --";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dowód osobisty:";
            // 
            // tPesel
            // 
            this.tPesel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tPesel.Location = new System.Drawing.Point(98, 169);
            this.tPesel.Name = "tPesel";
            this.tPesel.Size = new System.Drawing.Size(442, 20);
            this.tPesel.TabIndex = 18;
            this.tPesel.Text = "-- Nr PESEL --";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pesel:";
            // 
            // tStreet
            // 
            this.tStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tStreet.Location = new System.Drawing.Point(54, 93);
            this.tStreet.Name = "tStreet";
            this.tStreet.Size = new System.Drawing.Size(246, 20);
            this.tStreet.TabIndex = 11;
            this.tStreet.Text = "-- Miejscowość/Ulica + Nr Domu/Mieszkania --";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ulica:";
            // 
            // tZipCode
            // 
            this.tZipCode.Location = new System.Drawing.Point(98, 117);
            this.tZipCode.Name = "tZipCode";
            this.tZipCode.Size = new System.Drawing.Size(101, 20);
            this.tZipCode.TabIndex = 13;
            this.tZipCode.Text = "-- Kod Pocztowy --";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Kod Pocztowy:";
            // 
            // tCity
            // 
            this.tCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tCity.Location = new System.Drawing.Point(282, 117);
            this.tCity.Name = "tCity";
            this.tCity.Size = new System.Drawing.Size(258, 20);
            this.tCity.TabIndex = 15;
            this.tCity.Text = "-- Gmina/Miasto --";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Miejscowość:";
            // 
            // tSubjectOfAgreemnt
            // 
            this.tSubjectOfAgreemnt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tSubjectOfAgreemnt.Location = new System.Drawing.Point(107, 195);
            this.tSubjectOfAgreemnt.Name = "tSubjectOfAgreemnt";
            this.tSubjectOfAgreemnt.Size = new System.Drawing.Size(433, 20);
            this.tSubjectOfAgreemnt.TabIndex = 20;
            this.tSubjectOfAgreemnt.Text = "-- Opis Rzeczy --";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Przedmiot Umowy:";
            // 
            // tPurchasePriceInWords
            // 
            this.tPurchasePriceInWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tPurchasePriceInWords.Location = new System.Drawing.Point(126, 247);
            this.tPurchasePriceInWords.Name = "tPurchasePriceInWords";
            this.tPurchasePriceInWords.Size = new System.Drawing.Size(414, 20);
            this.tPurchasePriceInWords.TabIndex = 25;
            this.tPurchasePriceInWords.Text = "-- Cena Zakupu Słownie --";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 250);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Cena zakupu słownie:";
            // 
            // nudPurchasePrice
            // 
            this.nudPurchasePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPurchasePrice.DecimalPlaces = 2;
            this.nudPurchasePrice.Location = new System.Drawing.Point(126, 221);
            this.nudPurchasePrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPurchasePrice.Name = "nudPurchasePrice";
            this.nudPurchasePrice.Size = new System.Drawing.Size(73, 20);
            this.nudPurchasePrice.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Cena zakupu:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 275);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Cena wykupu:";
            // 
            // nudBuyoutPrice
            // 
            this.nudBuyoutPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBuyoutPrice.DecimalPlaces = 2;
            this.nudBuyoutPrice.Location = new System.Drawing.Point(126, 273);
            this.nudBuyoutPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudBuyoutPrice.Name = "nudBuyoutPrice";
            this.nudBuyoutPrice.Size = new System.Drawing.Size(73, 20);
            this.nudBuyoutPrice.TabIndex = 27;
            // 
            // tBuyoutPriceInWords
            // 
            this.tBuyoutPriceInWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBuyoutPriceInWords.Location = new System.Drawing.Point(126, 299);
            this.tBuyoutPriceInWords.Name = "tBuyoutPriceInWords";
            this.tBuyoutPriceInWords.Size = new System.Drawing.Size(414, 20);
            this.tBuyoutPriceInWords.TabIndex = 29;
            this.tBuyoutPriceInWords.Text = "-- Cena Wykupu Słownie --";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 302);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Cena wykupu słownie:";
            // 
            // bGeneratePDF
            // 
            this.bGeneratePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bGeneratePDF.Location = new System.Drawing.Point(677, 382);
            this.bGeneratePDF.Name = "bGeneratePDF";
            this.bGeneratePDF.Size = new System.Drawing.Size(99, 44);
            this.bGeneratePDF.TabIndex = 32;
            this.bGeneratePDF.Text = "Stwórz PDF";
            this.bGeneratePDF.UseVisualStyleBackColor = true;
            this.bGeneratePDF.Click += new System.EventHandler(this.bGeneratePDF_Click);
            // 
            // bSaveData
            // 
            this.bSaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSaveData.Location = new System.Drawing.Point(572, 382);
            this.bSaveData.Name = "bSaveData";
            this.bSaveData.Size = new System.Drawing.Size(99, 44);
            this.bSaveData.TabIndex = 33;
            this.bSaveData.Text = "Zapisz Dane";
            this.bSaveData.UseVisualStyleBackColor = true;
            this.bSaveData.Click += new System.EventHandler(this.bSaveData_Click);
            // 
            // bSaveClient
            // 
            this.bSaveClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSaveClient.Location = new System.Drawing.Point(677, 324);
            this.bSaveClient.Name = "bSaveClient";
            this.bSaveClient.Size = new System.Drawing.Size(99, 44);
            this.bSaveClient.TabIndex = 34;
            this.bSaveClient.Text = "Zapisz Klienta";
            this.bSaveClient.UseVisualStyleBackColor = true;
            this.bSaveClient.Click += new System.EventHandler(this.BSaveClient_Click);
            // 
            // cBoxClientsList
            // 
            this.cBoxClientsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBoxClientsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cBoxClientsList.FormattingEnabled = true;
            this.cBoxClientsList.Location = new System.Drawing.Point(84, 400);
            this.cBoxClientsList.Name = "cBoxClientsList";
            this.cBoxClientsList.Size = new System.Drawing.Size(351, 26);
            this.cBoxClientsList.TabIndex = 35;
            this.cBoxClientsList.DropDown += new System.EventHandler(this.CBoxClientsList_DropDown);
            this.cBoxClientsList.SelectedIndexChanged += new System.EventHandler(this.CBoxClientsList_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 407);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Lista klientów:";
            // 
            // bChooseClientFromCBox
            // 
            this.bChooseClientFromCBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bChooseClientFromCBox.Location = new System.Drawing.Point(441, 400);
            this.bChooseClientFromCBox.Name = "bChooseClientFromCBox";
            this.bChooseClientFromCBox.Size = new System.Drawing.Size(99, 26);
            this.bChooseClientFromCBox.TabIndex = 37;
            this.bChooseClientFromCBox.Text = "Wybierz";
            this.bChooseClientFromCBox.UseVisualStyleBackColor = true;
            this.bChooseClientFromCBox.Click += new System.EventHandler(this.BChooseClientFromCBox_Click);
            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 438);
            this.Controls.Add(this.bChooseClientFromCBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cBoxClientsList);
            this.Controls.Add(this.bSaveClient);
            this.Controls.Add(this.bSaveData);
            this.Controls.Add(this.bGeneratePDF);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudBuyoutPrice);
            this.Controls.Add(this.tBuyoutPriceInWords);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudPurchasePrice);
            this.Controls.Add(this.tPurchasePriceInWords);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tSubjectOfAgreemnt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tCity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tZipCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tStreet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tPesel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tIDCard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFrom);
            this.Name = "AddCustomerForm";
            this.Text = "Generator Umowy";
            ((System.ComponentModel.ISupportInitialize)(this.nudPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuyoutPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.TextBox tIDCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tPesel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tStreet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tZipCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tSubjectOfAgreemnt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tPurchasePriceInWords;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudPurchasePrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudBuyoutPrice;
        private System.Windows.Forms.TextBox tBuyoutPriceInWords;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button bGeneratePDF;
        private System.Windows.Forms.Button bSaveData;
        private System.Windows.Forms.Button bSaveClient;
        private System.Windows.Forms.ComboBox cBoxClientsList;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button bChooseClientFromCBox;
    }
}

