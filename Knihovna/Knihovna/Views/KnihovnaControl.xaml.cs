﻿using Knihovna.Model;
using Knihovna.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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

namespace Knihovna.Views
{
    /// <summary>
    /// Interaction logic for KnihovnaControl.xaml
    /// </summary>
    public partial class KnihovnaControl : UserControl
    {
        public KnihovnaControl()
        {
            InitializeComponent();
            ViewModel.KnihovnaViewModel.Knihovny = new();
            ViewModel.KnihaViewModel.Knihy = new();
            ViewModel.ZakazniciViewModel.Zakaznici = new();
            ViewModel.VypujckyViewModel.Vypujcky = new();
            ViewModel.KnihaViewModel.LoadKnihy();
            ViewModel.ZakazniciViewModel.LoadZakaznici();
            ViewModel.VypujckyViewModel.LoadVypujcky();
            ViewModel.KnihovnaViewModel.LoadKnihovny();
            lv1.ItemsSource = KnihovnaViewModel.Knihovny;
           
        }

        //ADD
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add page = new Add();
            page.Show(); 
            lv1.Items.Refresh();
        }

        //DELETE
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                KnihovnaViewModel.removeKnihovny((Knihovny)lv1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Není vybráno oddělení", "Chyba");
            }
        }

        //EDIT
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                Knihovny knihovna = (Knihovny)lv1.SelectedItem;
                AddEditControl.nazev = knihovna.Nazev;
                Add page = new Add();
                page.Show();
               
            }
            else
            {
                MessageBox.Show("Není vybráno oddělení", "Chyba");
            }
        }

        //doubleClick
        private void detailOpen(object sender, MouseButtonEventArgs e)
        {
            if (lv1.SelectedItems.Count > 0)
            {
                Knihovny knihovna = (Knihovny)lv1.SelectedItem;
            DetailOddeleni.nazev = knihovna.Nazev;
            DetailOddeleni.odd = knihovna;
            detailOdd page = new detailOdd();
            page.Show();
            }
            else
            {
                MessageBox.Show("Není vybráno Oddělení", "Chyba");
            }
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete) {
                if (lv1.SelectedItems.Count > 0)
                {
                    KnihovnaViewModel.Knihovny.Remove((Knihovny)lv1.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Není vybráno Oddělení", "Chyba");
                }
            }else if(e.Key == Key.Enter) {
                if (lv1.SelectedItems.Count > 0)
                {
                    Knihovny knihovna = (Knihovny)lv1.SelectedItem;
                    DetailOddeleni.nazev = knihovna.Nazev;
                    DetailOddeleni.odd = knihovna;
                    detailOdd page = new detailOdd();
                    page.Show();
                }
                else
                {
                    MessageBox.Show("Není vybráno Oddělení", "Chyba");
                }

            }
        }
    }
}
