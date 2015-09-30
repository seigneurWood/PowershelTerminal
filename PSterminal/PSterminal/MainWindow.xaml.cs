﻿using System;
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

namespace PSterminal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Terminal terminal = new Terminal();
        public MainWindow()
        {
            InitializeComponent();
            //TextBox t = new TextBox();
            //t.Undo();
            terminal.Script = TextScript.Text;
            UndoRedoCommand._Undocommands = new Stack<Command>();
            UndoRedoCommand._Redocommands = new Stack<Command>();
        }

        private void TextScript_KeyUp(object sender, KeyEventArgs e)
        {
            terminal.Script = TextScript.Text;
            terminal.TypeScript(TextScript.Text[TextScript.Text.Length - 1]);
        }

        private void miUndo_Click(object sender, RoutedEventArgs e)
        {
            UndoRedoCommand u = new UndoRedoCommand();
            u.Undo(1);
            //TextScript.Text = terminal.Script;
        }

        private void miRedo_Click(object sender, RoutedEventArgs e)
        {
            UndoRedoCommand u = new UndoRedoCommand();
            u.Redo(1);
        }
    }
}
