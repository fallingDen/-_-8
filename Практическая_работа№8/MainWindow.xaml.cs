using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая_работа_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Выход(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_О_программе(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автор: Соколов Даниил \n" +
            "Практическая работа №8 \n Задание: Создать интерфейсы - корабль, грузовой транспорт. Создать класс грузовой корабль.\n Класс должен включать конструктор, функцию для формирования строки \nинформации о корабле. Сравнение производить по грузоподъемности.");
        }

        private void MenuItem_Click_Анекдот(object sender, RoutedEventArgs e)
        {
            if (List.Items.Count < 1) 
            {
                MessageBox.Show("Абсолютное ничего p.s.(добавьте хотя бы один корабль)");
                return;
            }

            string content = "";


            for (int i = 0; i < List.Items.Count; i++)
            {
                content += $"К нему доплывает {i+1}-й корабль.\n— Вам помочь?\n— Нет. Бог поможет.\n";
            }
            
            MessageBox.Show($"Тонет человек посреди моря. к нему доплывает корабль.\n{content}Ну и утонул он. Попадает значит к богу и спрашивает:\n— Почему же ты мне не помог?\n— Глупец! Я тебе {List.Items.Count} корабля прислал...");

        }

        private void B_Записать_Click(object sender, RoutedEventArgs e)
             { 
            if (!(TBГрузовойКорабль.Text != "" &&
             !string.IsNullOrWhiteSpace (TBГрузовойКорабль.Text) 
            && int.TryParse(TBГрузоподъёмность.Text, out int b)
            && b > 0))
            {

                MessageBox.Show("Давай всё правильно вводи");
                return;
            }
                ГрузовойКорабль q = new ГрузовойКорабль(TBГрузовойКорабль.Text, b);
                q.N = List.Items.Count + 1;
                List.Items.Add(q);
        }

        private void B_Сравнить_Click(object sender, RoutedEventArgs e)
        {
            if (!(int.TryParse(TbПервыйТраспорт.Text, out int a)
            && int.TryParse(TbВторойТранспорт.Text, out int b)
            && a > 0
            && b > 0
            && a < List.Items.Count + 1
            && b < List.Items.Count + 1))
            {
               MessageBox.Show("Всё ....., давай по новой") ;
               return;
            }
                ГрузовойКорабль one = (ГрузовойКорабль)List.Items[a - 1];
                ГрузовойКорабль second = (ГрузовойКорабль)List.Items[b - 1];
                int rez = one.CompareTo(second);
                switch (rez)
                {
                    case 1: MessageBox.Show("Грузоподъёмность первого больше чем второго"); break;
                    case 0: MessageBox.Show(" Интересный результат "); break;
                    case -1: MessageBox.Show("Грузоподъёмность второго больше чем первого "); break;
                }
        }

        private void Button_Копировать(object sender, RoutedEventArgs e)
        {
            if (!(int.TryParse(TbНомерКопируемойСтроки.Text, out int x)
            && x < List.Items.Count + 1))
            {
                MessageBox.Show("Давай всё правильно вводи");
                return;
            }

                ГрузовойКорабль one = (ГрузовойКорабль)List.Items[x - 1];     
                ГрузовойКорабль n = (ГрузовойКорабль)one.Clone();
                n.N = List.Items.Count + 1;
                List.Items.Add(n);
                
                
               

        }
    }
}
