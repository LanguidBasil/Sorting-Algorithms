
namespace Lab1
{
	partial class Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
			this.ArrayInButton = new System.Windows.Forms.Button();
			this.ArrayInLabel = new System.Windows.Forms.Label();
			this.ArrayInPanel = new System.Windows.Forms.Panel();
			this.ArrayInPreviewLabel = new System.Windows.Forms.Label();
			this.ArrayInPicture = new System.Windows.Forms.PictureBox();
			this.ArrayInDialog = new System.Windows.Forms.OpenFileDialog();
			this.SortMethodNumbersDropDown = new System.Windows.Forms.ComboBox();
			this.SortMethodText = new System.Windows.Forms.Label();
			this.SortButton = new System.Windows.Forms.Button();
			this.SortedTable = new System.Windows.Forms.TableLayoutPanel();
			this.SortedTableLabel = new System.Windows.Forms.Label();
			this.SortedArrayLabel = new System.Windows.Forms.Label();
			this.SortedArray = new System.Windows.Forms.TextBox();
			this.ArrayInPreview = new System.Windows.Forms.TextBox();
			this.SortedTableButton = new System.Windows.Forms.Button();
			this.SortedTableSaveDialog = new System.Windows.Forms.SaveFileDialog();
			this.ArrayInPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ArrayInPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// ArrayInButton
			// 
			this.ArrayInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.ArrayInButton.Location = new System.Drawing.Point(512, 18);
			this.ArrayInButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ArrayInButton.Name = "ArrayInButton";
			this.ArrayInButton.Size = new System.Drawing.Size(119, 30);
			this.ArrayInButton.TabIndex = 0;
			this.ArrayInButton.Text = "Выбрать файл";
			this.ArrayInButton.UseVisualStyleBackColor = true;
			this.ArrayInButton.Click += new System.EventHandler(this.ArrayInButton_Click);
			// 
			// ArrayInLabel
			// 
			this.ArrayInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ArrayInLabel.Location = new System.Drawing.Point(52, 23);
			this.ArrayInLabel.Name = "ArrayInLabel";
			this.ArrayInLabel.Size = new System.Drawing.Size(455, 20);
			this.ArrayInLabel.TabIndex = 2;
			this.ArrayInLabel.Text = "Файл отсутствует";
			// 
			// ArrayInPanel
			// 
			this.ArrayInPanel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ArrayInPanel.Controls.Add(this.ArrayInPreviewLabel);
			this.ArrayInPanel.Controls.Add(this.ArrayInPicture);
			this.ArrayInPanel.Controls.Add(this.ArrayInButton);
			this.ArrayInPanel.Controls.Add(this.ArrayInLabel);
			this.ArrayInPanel.Location = new System.Drawing.Point(12, 12);
			this.ArrayInPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ArrayInPanel.Name = "ArrayInPanel";
			this.ArrayInPanel.Size = new System.Drawing.Size(648, 213);
			this.ArrayInPanel.TabIndex = 3;
			// 
			// ArrayInPreviewLabel
			// 
			this.ArrayInPreviewLabel.AutoSize = true;
			this.ArrayInPreviewLabel.Location = new System.Drawing.Point(13, 62);
			this.ArrayInPreviewLabel.Name = "ArrayInPreviewLabel";
			this.ArrayInPreviewLabel.Size = new System.Drawing.Size(122, 17);
			this.ArrayInPreviewLabel.TabIndex = 4;
			this.ArrayInPreviewLabel.Text = "Массив из файла";
			// 
			// ArrayInPicture
			// 
			this.ArrayInPicture.Image = ((System.Drawing.Image)(resources.GetObject("ArrayInPicture.Image")));
			this.ArrayInPicture.InitialImage = null;
			this.ArrayInPicture.Location = new System.Drawing.Point(13, 18);
			this.ArrayInPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ArrayInPicture.Name = "ArrayInPicture";
			this.ArrayInPicture.Size = new System.Drawing.Size(33, 30);
			this.ArrayInPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ArrayInPicture.TabIndex = 1;
			this.ArrayInPicture.TabStop = false;
			// 
			// ArrayInDialog
			// 
			this.ArrayInDialog.FileName = "ArrayInDialog";
			// 
			// SortMethodNumbersDropDown
			// 
			this.SortMethodNumbersDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SortMethodNumbersDropDown.ForeColor = System.Drawing.Color.Black;
			this.SortMethodNumbersDropDown.FormattingEnabled = true;
			this.SortMethodNumbersDropDown.Items.AddRange(new object[] {
            "Простые вставки",
            "Простой обмен",
            "Простой выбор",
            "Гномья сортировка",
            "Быстрая сортировка"});
			this.SortMethodNumbersDropDown.Location = new System.Drawing.Point(692, 64);
			this.SortMethodNumbersDropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.SortMethodNumbersDropDown.Name = "SortMethodNumbersDropDown";
			this.SortMethodNumbersDropDown.Size = new System.Drawing.Size(188, 24);
			this.SortMethodNumbersDropDown.TabIndex = 1;
			// 
			// SortMethodText
			// 
			this.SortMethodText.AutoSize = true;
			this.SortMethodText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SortMethodText.Location = new System.Drawing.Point(688, 31);
			this.SortMethodText.Name = "SortMethodText";
			this.SortMethodText.Size = new System.Drawing.Size(168, 20);
			this.SortMethodText.TabIndex = 5;
			this.SortMethodText.Text = "Метод сортировки";
			// 
			// SortButton
			// 
			this.SortButton.Location = new System.Drawing.Point(692, 198);
			this.SortButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.SortButton.Name = "SortButton";
			this.SortButton.Size = new System.Drawing.Size(121, 27);
			this.SortButton.TabIndex = 2;
			this.SortButton.Text = "Сортировать";
			this.SortButton.UseVisualStyleBackColor = true;
			this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
			// 
			// SortedTable
			// 
			this.SortedTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.SortedTable.ColumnCount = 5;
			this.SortedTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
			this.SortedTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
			this.SortedTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
			this.SortedTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
			this.SortedTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
			this.SortedTable.Location = new System.Drawing.Point(12, 273);
			this.SortedTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.SortedTable.Name = "SortedTable";
			this.SortedTable.RowCount = 6;
			this.SortedTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.SortedTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.SortedTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.SortedTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.SortedTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.SortedTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.SortedTable.Size = new System.Drawing.Size(648, 268);
			this.SortedTable.TabIndex = 9;
			// 
			// SortedTableLabel
			// 
			this.SortedTableLabel.AutoSize = true;
			this.SortedTableLabel.Location = new System.Drawing.Point(25, 244);
			this.SortedTableLabel.Name = "SortedTableLabel";
			this.SortedTableLabel.Size = new System.Drawing.Size(196, 17);
			this.SortedTableLabel.TabIndex = 5;
			this.SortedTableLabel.Text = "Характеристики сортировок";
			// 
			// SortedArrayLabel
			// 
			this.SortedArrayLabel.AutoSize = true;
			this.SortedArrayLabel.Location = new System.Drawing.Point(688, 244);
			this.SortedArrayLabel.Name = "SortedArrayLabel";
			this.SortedArrayLabel.Size = new System.Drawing.Size(163, 17);
			this.SortedArrayLabel.TabIndex = 5;
			this.SortedArrayLabel.Text = "Сортированный массив";
			// 
			// SortedArray
			// 
			this.SortedArray.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.SortedArray.Location = new System.Drawing.Point(680, 273);
			this.SortedArray.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.SortedArray.Multiline = true;
			this.SortedArray.Name = "SortedArray";
			this.SortedArray.ReadOnly = true;
			this.SortedArray.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.SortedArray.Size = new System.Drawing.Size(200, 266);
			this.SortedArray.TabIndex = 6;
			this.SortedArray.TabStop = false;
			// 
			// ArrayInPreview
			// 
			this.ArrayInPreview.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.ArrayInPreview.Location = new System.Drawing.Point(25, 94);
			this.ArrayInPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ArrayInPreview.Multiline = true;
			this.ArrayInPreview.Name = "ArrayInPreview";
			this.ArrayInPreview.ReadOnly = true;
			this.ArrayInPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ArrayInPreview.Size = new System.Drawing.Size(616, 120);
			this.ArrayInPreview.TabIndex = 10;
			this.ArrayInPreview.TabStop = false;
			// 
			// SortedTableButton
			// 
			this.SortedTableButton.Location = new System.Drawing.Point(505, 238);
			this.SortedTableButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.SortedTableButton.Name = "SortedTableButton";
			this.SortedTableButton.Size = new System.Drawing.Size(155, 27);
			this.SortedTableButton.TabIndex = 11;
			this.SortedTableButton.Text = "Сохранить таблицу";
			this.SortedTableButton.UseVisualStyleBackColor = true;
			this.SortedTableButton.Click += new System.EventHandler(this.SortedTableButton_Click);
			// 
			// SortedTableSaveDialog
			// 
			this.SortedTableSaveDialog.Filter = "Text file|*.txt|Any file|*.*";
			// 
			// Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 555);
			this.Controls.Add(this.SortedTableButton);
			this.Controls.Add(this.ArrayInPreview);
			this.Controls.Add(this.SortedArray);
			this.Controls.Add(this.SortedArrayLabel);
			this.Controls.Add(this.SortedTableLabel);
			this.Controls.Add(this.SortedTable);
			this.Controls.Add(this.SortButton);
			this.Controls.Add(this.SortMethodText);
			this.Controls.Add(this.SortMethodNumbersDropDown);
			this.Controls.Add(this.ArrayInPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form";
			this.Text = "Сортировка";
			this.ArrayInPanel.ResumeLayout(false);
			this.ArrayInPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ArrayInPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ArrayInButton;
		private System.Windows.Forms.PictureBox ArrayInPicture;
		private System.Windows.Forms.Label ArrayInLabel;
		private System.Windows.Forms.Panel ArrayInPanel;
		private System.Windows.Forms.OpenFileDialog ArrayInDialog;
		private System.Windows.Forms.Label ArrayInPreviewLabel;
		private System.Windows.Forms.ComboBox SortMethodNumbersDropDown;
		private System.Windows.Forms.Label SortMethodText;
		private System.Windows.Forms.Button SortButton;
		private System.Windows.Forms.TableLayoutPanel SortedTable;
		private System.Windows.Forms.Label SortedTableLabel;
		private System.Windows.Forms.Label SortedArrayLabel;
		private System.Windows.Forms.TextBox SortedArray;
		private System.Windows.Forms.TextBox ArrayInPreview;
		private System.Windows.Forms.Button SortedTableButton;
		private System.Windows.Forms.SaveFileDialog SortedTableSaveDialog;
	}
}

