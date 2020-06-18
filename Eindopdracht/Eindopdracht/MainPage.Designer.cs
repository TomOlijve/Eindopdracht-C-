using System;

namespace Eindopdracht
{
    partial class MainPage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.actueel = new System.Windows.Forms.TabPage();
            this.currentLocation = new System.Windows.Forms.Label();
            this.currentIcon = new System.Windows.Forms.PictureBox();
            this.currentWindSpeed = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.currentWindDirection = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lastUpdated = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.currentWeatherInfo = new System.Windows.Forms.Label();
            this.currentHumidity = new System.Windows.Forms.Label();
            this.currentTemperature = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trend = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.opties = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.temperatureUnit_Fahrenheit = new System.Windows.Forms.RadioButton();
            this.temperatureUnit_Celsius = new System.Windows.Forms.RadioButton();
            this.intervalInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.locationInput = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.currentTemperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verversenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.actueel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentIcon)).BeginInit();
            this.trend.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.opties.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.actueel);
            this.tabControl.Controls.Add(this.trend);
            this.tabControl.Controls.Add(this.opties);
            this.tabControl.Location = new System.Drawing.Point(-6, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(711, 447);
            this.tabControl.TabIndex = 0;
            // 
            // actueel
            // 
            this.actueel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.actueel.Controls.Add(this.currentLocation);
            this.actueel.Controls.Add(this.currentIcon);
            this.actueel.Controls.Add(this.currentWindSpeed);
            this.actueel.Controls.Add(this.label11);
            this.actueel.Controls.Add(this.currentWindDirection);
            this.actueel.Controls.Add(this.label9);
            this.actueel.Controls.Add(this.lastUpdated);
            this.actueel.Controls.Add(this.label7);
            this.actueel.Controls.Add(this.currentWeatherInfo);
            this.actueel.Controls.Add(this.currentHumidity);
            this.actueel.Controls.Add(this.currentTemperature);
            this.actueel.Controls.Add(this.label6);
            this.actueel.Controls.Add(this.label8);
            this.actueel.Controls.Add(this.label5);
            this.actueel.Controls.Add(this.label4);
            this.actueel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actueel.Location = new System.Drawing.Point(4, 22);
            this.actueel.Name = "actueel";
            this.actueel.Padding = new System.Windows.Forms.Padding(3);
            this.actueel.Size = new System.Drawing.Size(703, 421);
            this.actueel.TabIndex = 0;
            this.actueel.Text = "Actueel";
            // 
            // currentLocation
            // 
            this.currentLocation.AutoSize = true;
            this.currentLocation.ForeColor = System.Drawing.Color.Transparent;
            this.currentLocation.Location = new System.Drawing.Point(453, 69);
            this.currentLocation.Name = "currentLocation";
            this.currentLocation.Size = new System.Drawing.Size(59, 18);
            this.currentLocation.TabIndex = 17;
            this.currentLocation.Text = "label10";
            // 
            // currentIcon
            // 
            this.currentIcon.Location = new System.Drawing.Point(592, 56);
            this.currentIcon.Name = "currentIcon";
            this.currentIcon.Size = new System.Drawing.Size(59, 49);
            this.currentIcon.TabIndex = 16;
            this.currentIcon.TabStop = false;
            // 
            // currentWindSpeed
            // 
            this.currentWindSpeed.AutoSize = true;
            this.currentWindSpeed.ForeColor = System.Drawing.Color.White;
            this.currentWindSpeed.Location = new System.Drawing.Point(207, 248);
            this.currentWindSpeed.Name = "currentWindSpeed";
            this.currentWindSpeed.Size = new System.Drawing.Size(59, 18);
            this.currentWindSpeed.TabIndex = 15;
            this.currentWindSpeed.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(56, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 18);
            this.label11.TabIndex = 14;
            this.label11.Text = "Windsnelheid";
            // 
            // currentWindDirection
            // 
            this.currentWindDirection.AutoSize = true;
            this.currentWindDirection.ForeColor = System.Drawing.Color.White;
            this.currentWindDirection.Location = new System.Drawing.Point(207, 203);
            this.currentWindDirection.Name = "currentWindDirection";
            this.currentWindDirection.Size = new System.Drawing.Size(59, 18);
            this.currentWindDirection.TabIndex = 13;
            this.currentWindDirection.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(56, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 18);
            this.label9.TabIndex = 12;
            this.label9.Text = "Windrichting";
            // 
            // lastUpdated
            // 
            this.lastUpdated.AutoSize = true;
            this.lastUpdated.ForeColor = System.Drawing.Color.White;
            this.lastUpdated.Location = new System.Drawing.Point(207, 298);
            this.lastUpdated.Name = "lastUpdated";
            this.lastUpdated.Size = new System.Drawing.Size(50, 18);
            this.lastUpdated.TabIndex = 11;
            this.lastUpdated.Text = "label9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(56, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Laatst geupdated";
            // 
            // currentWeatherInfo
            // 
            this.currentWeatherInfo.AutoSize = true;
            this.currentWeatherInfo.ForeColor = System.Drawing.Color.White;
            this.currentWeatherInfo.Location = new System.Drawing.Point(207, 156);
            this.currentWeatherInfo.Name = "currentWeatherInfo";
            this.currentWeatherInfo.Size = new System.Drawing.Size(50, 18);
            this.currentWeatherInfo.TabIndex = 9;
            this.currentWeatherInfo.Text = "label9";
            // 
            // currentHumidity
            // 
            this.currentHumidity.AutoSize = true;
            this.currentHumidity.ForeColor = System.Drawing.Color.White;
            this.currentHumidity.Location = new System.Drawing.Point(207, 110);
            this.currentHumidity.Name = "currentHumidity";
            this.currentHumidity.Size = new System.Drawing.Size(50, 18);
            this.currentHumidity.TabIndex = 8;
            this.currentHumidity.Text = "label7";
            // 
            // currentTemperature
            // 
            this.currentTemperature.AutoSize = true;
            this.currentTemperature.ForeColor = System.Drawing.Color.White;
            this.currentTemperature.Location = new System.Drawing.Point(207, 56);
            this.currentTemperature.Name = "currentTemperature";
            this.currentTemperature.Size = new System.Drawing.Size(50, 18);
            this.currentTemperature.TabIndex = 7;
            this.currentTemperature.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(56, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Luchtvochtigheid";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(56, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 18);
            this.label8.TabIndex = 5;
            this.label8.Text = "Temperatuur";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 18);
            this.label5.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(56, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Weather";
            // 
            // trend
            // 
            this.trend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.trend.Controls.Add(this.tabControl1);
            this.trend.Controls.Add(this.chart);
            this.trend.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trend.Location = new System.Drawing.Point(4, 22);
            this.trend.Name = "trend";
            this.trend.Padding = new System.Windows.Forms.Padding(3);
            this.trend.Size = new System.Drawing.Size(703, 421);
            this.trend.TabIndex = 1;
            this.trend.Text = "Trend";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(573, 231);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(8, 8);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(0, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Temperature";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(703, 418);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            title1.Name = "Title1";
            title1.Text = "Temperature per Time";
            this.chart.Titles.Add(title1);
            // 
            // opties
            // 
            this.opties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.opties.Controls.Add(this.button1);
            this.opties.Controls.Add(this.temperatureUnit_Fahrenheit);
            this.opties.Controls.Add(this.temperatureUnit_Celsius);
            this.opties.Controls.Add(this.intervalInput);
            this.opties.Controls.Add(this.label3);
            this.opties.Controls.Add(this.label2);
            this.opties.Controls.Add(this.label1);
            this.opties.Controls.Add(this.locationInput);
            this.opties.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.opties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.opties.Location = new System.Drawing.Point(4, 22);
            this.opties.Name = "opties";
            this.opties.Size = new System.Drawing.Size(703, 421);
            this.opties.TabIndex = 2;
            this.opties.Text = "Opties";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UpdateSettings);
            // 
            // temperatureUnit_Fahrenheit
            // 
            this.temperatureUnit_Fahrenheit.AutoSize = true;
            this.temperatureUnit_Fahrenheit.Location = new System.Drawing.Point(369, 228);
            this.temperatureUnit_Fahrenheit.Name = "temperatureUnit_Fahrenheit";
            this.temperatureUnit_Fahrenheit.Size = new System.Drawing.Size(31, 17);
            this.temperatureUnit_Fahrenheit.TabIndex = 6;
            this.temperatureUnit_Fahrenheit.TabStop = true;
            this.temperatureUnit_Fahrenheit.Text = "F";
            this.temperatureUnit_Fahrenheit.UseVisualStyleBackColor = true;
            // 
            // temperatureUnit_Celsius
            // 
            this.temperatureUnit_Celsius.AutoSize = true;
            this.temperatureUnit_Celsius.Location = new System.Drawing.Point(300, 228);
            this.temperatureUnit_Celsius.Name = "temperatureUnit_Celsius";
            this.temperatureUnit_Celsius.Size = new System.Drawing.Size(32, 17);
            this.temperatureUnit_Celsius.TabIndex = 5;
            this.temperatureUnit_Celsius.TabStop = true;
            this.temperatureUnit_Celsius.Text = "C";
            this.temperatureUnit_Celsius.UseVisualStyleBackColor = true;
            // 
            // intervalInput
            // 
            this.intervalInput.Location = new System.Drawing.Point(300, 171);
            this.intervalInput.Name = "intervalInput";
            this.intervalInput.Size = new System.Drawing.Size(100, 20);
            this.intervalInput.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Weergave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interval";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plaats:";
            // 
            // locationInput
            // 
            this.locationInput.Location = new System.Drawing.Point(300, 121);
            this.locationInput.Name = "locationInput";
            this.locationInput.Size = new System.Drawing.Size(100, 20);
            this.locationInput.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentTemperatureToolStripMenuItem,
            this.overToolStripMenuItem,
            this.verversenToolStripMenuItem,
            this.optiesToolStripMenuItem,
            this.openenToolStripMenuItem,
            this.sluitenToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(181, 136);
            // 
            // currentTemperatureToolStripMenuItem
            // 
            this.currentTemperatureToolStripMenuItem.Name = "currentTemperatureToolStripMenuItem";
            this.currentTemperatureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.currentTemperatureToolStripMenuItem.Text = "CurrentTemperature";
            // 
            // overToolStripMenuItem
            // 
            this.overToolStripMenuItem.Name = "overToolStripMenuItem";
            this.overToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.overToolStripMenuItem.Text = "Over";
            this.overToolStripMenuItem.Click += new System.EventHandler(this.overToolStripMenuItem_Click);
            // 
            // verversenToolStripMenuItem
            // 
            this.verversenToolStripMenuItem.Name = "verversenToolStripMenuItem";
            this.verversenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verversenToolStripMenuItem.Text = "Verversen";
            this.verversenToolStripMenuItem.Click += new System.EventHandler(this.verversenToolStripMenuItem_Click);
            // 
            // optiesToolStripMenuItem
            // 
            this.optiesToolStripMenuItem.Name = "optiesToolStripMenuItem";
            this.optiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optiesToolStripMenuItem.Text = "Opties";
            this.optiesToolStripMenuItem.Click += new System.EventHandler(this.optiesToolStripMenuItem_Click);
            // 
            // openenToolStripMenuItem
            // 
            this.openenToolStripMenuItem.Name = "openenToolStripMenuItem";
            this.openenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openenToolStripMenuItem.Text = "Openen";
            this.openenToolStripMenuItem.Click += new System.EventHandler(this.openenToolStripMenuItem_Click);
            // 
            // sluitenToolStripMenuItem
            // 
            this.sluitenToolStripMenuItem.Name = "sluitenToolStripMenuItem";
            this.sluitenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sluitenToolStripMenuItem.Text = "Sluiten";
            this.sluitenToolStripMenuItem.Click += new System.EventHandler(this.sluitenToolStripMenuItem_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.tabControl);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.tabControl.ResumeLayout(false);
            this.actueel.ResumeLayout(false);
            this.actueel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentIcon)).EndInit();
            this.trend.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.opties.ResumeLayout(false);
            this.opties.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage actueel;
        private System.Windows.Forms.TabPage trend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage opties;
        private System.Windows.Forms.TextBox locationInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton temperatureUnit_Fahrenheit;
        private System.Windows.Forms.RadioButton temperatureUnit_Celsius;
        private System.Windows.Forms.TextBox intervalInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem overToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verversenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sluitenToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label currentTemperature;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentWeatherInfo;
        private System.Windows.Forms.Label currentHumidity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lastUpdated;
        private System.Windows.Forms.Label currentWindSpeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label currentWindDirection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox currentIcon;
        private System.Windows.Forms.Label currentLocation;
        private System.Windows.Forms.ToolStripMenuItem currentTemperatureToolStripMenuItem;
    }
}