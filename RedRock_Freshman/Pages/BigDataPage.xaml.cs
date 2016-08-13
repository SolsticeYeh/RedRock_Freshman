using RedRock_Freshman.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace RedRock_Freshman.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BigDataPage : Page
    {
        private int pivot_index = 0;
        private int comboBox1_index = 0;
        public BigDataPage()
        {
            this.InitializeComponent();
            comboBox0.ItemsSource = colleage;
            comboBox1.ItemsSource = attention;
            comboBox2.ItemsSource = colleage;
            comboBox3.ItemsSource = colleage;
        }

        public string[] colleage = {"光电工程学院",
                                    "经济管理学院",
                                    "国际学院",
                                    "法学院",
                                    "传媒艺术学院",
                                    "通信与信息工程学院",
                                    "计算机科学与技术学院",
                                    "软件工程学院",
                                    "体育学院",
                                    "生物信息学院",
                                    "理学院",
                                    "先进制造工程学院",
                                    "外国语学院",
                                    "自动化学院" };
        public string[] attention = { "学院都没选就想看专业，哼~" };

        private void comboBox0_DropDownClosed(object sender, object e)
        {
            if (comboBox0.SelectedItem == null)
            {
                comboBox1.ItemsSource = attention;
                return;
            }
            comboBox1.ItemsSource = Switch.MajorSwitch(comboBox0.SelectedItem.ToString());
        }

        private void comboBox1_DropDownClosed(object sender, object e)
        {
            if (comboBox1.SelectedItem == null)
                return;
            try
            {
                TextBlock1.Text = comboBox0.SelectedItem.ToString() + "-" + comboBox1.SelectedItem.ToString() + "专业的男女比例饼图如下";
                Male.Text = Switch.SexRatioSwitch(comboBox1.SelectedItem.ToString()).MaleRatio.ToString() + "  " + "(" + Switch.SexRatioSwitch(comboBox1.SelectedItem.ToString()).Male.ToString() + "人)";
                Female.Text = Switch.SexRatioSwitch(comboBox1.SelectedItem.ToString()).FemaleRatio.ToString() + "  " + "(" + Switch.SexRatioSwitch(comboBox1.SelectedItem.ToString()).Female.ToString() + "人)"; ;
            }
            catch
            {
                return;
            }
            List<PieDataItem> datas = new List<PieDataItem>();
            datas.Add(new PieDataItem { Value = Switch.SexRatioSwitch(comboBox1.SelectedItem.ToString()).Male, Brush = new SolidColorBrush(Colors.Purple) });
            datas.Add(new PieDataItem { Value = Switch.SexRatioSwitch(comboBox1.SelectedItem.ToString()).Female, Brush = new SolidColorBrush(Colors.Pink) });
            piePlotter0.DataContext = datas;
            piePlotter0.ShowPie();
        }

        private void comboBox2_DropDownClosed(object sender, object e)
        {
            if (comboBox2.SelectedItem == null)
                return;
            try
            {
                TextBlock2.Text = comboBox2.SelectedItem.ToString() + "的最难科目饼图如下";
                Sub1.Text = "1." + Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).Hardest.ToString() + "   " + "(" + Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).HardestRatio.ToString() + "%)";
                Sub2.Text = "2." + Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).Harder.ToString() + "   " + "(" + Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).HarderRatio.ToString() + "%)";
                Sub3.Text = "3." + Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).Hard.ToString() + "   " + "(" + Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).HardRatio.ToString() + "%)";
            }
            catch
            {
                return;
            }
            List<PieDataItem> datas = new List<PieDataItem>();
            datas.Add(new PieDataItem { Value = Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).HardestRatio, Brush = new SolidColorBrush(Colors.Purple) });
            datas.Add(new PieDataItem { Value = Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).HarderRatio, Brush = new SolidColorBrush(Colors.LightSkyBlue) });
            datas.Add(new PieDataItem { Value = Switch.SubjectRatioSwitch(comboBox2.SelectedItem.ToString()).HardRatio, Brush = new SolidColorBrush(Colors.Pink) });
            piePlotter1.DataContext = datas;
            piePlotter1.ShowPie();
        }

        private void comboBox3_DropDownClosed(object sender, object e)
        {
            if (comboBox3.SelectedItem == null)
                return;
            try
            {
                TextBlock3.Text = comboBox3.SelectedItem.ToString() + "的毕业去向饼图如下";
                Road1.Text += Switch.CareerRatioSwitch(comboBox3.SelectedItem.ToString()).Employed.ToString() + "%";
                Road2.Text += Switch.CareerRatioSwitch(comboBox3.SelectedItem.ToString()).Abroad.ToString() + "%";
                Road3.Text += Switch.CareerRatioSwitch(comboBox3.SelectedItem.ToString()).Unemployed.ToString() + "%";
                Road4.Text += Switch.CareerRatioSwitch(comboBox3.SelectedItem.ToString()).FreeWork.ToString() + "%";
            }
            catch
            {
                return;
            }
            List<PieDataItem> datas = new List<PieDataItem>();
            datas.Add(new PieDataItem { Value = Switch.CareerRatioSwitch(comboBox3.SelectedItem.ToString()).Employed, Brush = new SolidColorBrush(Colors.Purple) });
            datas.Add(new PieDataItem { Value = Switch.CareerRatioSwitch(comboBox3.SelectedItem.ToString()).Abroad, Brush = new SolidColorBrush(Colors.Pink) });
            datas.Add(new PieDataItem { Value = Switch.CareerRatioSwitch(comboBox3.SelectedItem.ToString()).Unemployed, Brush = new SolidColorBrush(Colors.LightSkyBlue) });
            datas.Add(new PieDataItem { Value = Switch.CareerRatioSwitch(comboBox3.SelectedItem.ToString()).FreeWork, Brush = new SolidColorBrush(Colors.Cyan) });
            piePlotter2.DataContext = datas;
            piePlotter2.ShowPie();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            FirstPage.firstpage.Second_Page_Back();
        }

        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (pivot.SelectedIndex < 0)
                {
                    pivot.SelectedIndex = pivot_index = 0;
                }
                (((pivot.Items[pivot_index] as PivotItem).Header as Grid).Children[0] as TextBlock).Foreground = App.APPTheme.Content_Header_Color_Brush;
                (((pivot.Items[pivot_index] as PivotItem).Header as Grid).Children[1] as Line).Visibility = Visibility.Collapsed;
                pivot_index = pivot.SelectedIndex;
                (((pivot.Items[pivot_index] as PivotItem).Header as Grid).Children[0] as TextBlock).Foreground = App.APPTheme.APP_Color_Brush;
                (((pivot.Items[pivot_index] as PivotItem).Header as Grid).Children[1] as Line).Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
