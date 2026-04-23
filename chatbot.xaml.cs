using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;


namespace FRANK_CHATBOT_PART2
{
    /// <summary>
    /// Interaction logic for chatbot.xaml
    /// </summary>
    public partial class chatbot : Window
    {
        public chatbot()
        {
            InitializeComponent();
            // Display personalized  welcome message when the program starts
            AddMessage($"Welcome {Session.UserName}, I'm FRANK. Ask me about cybersecurity.", false);
        }
        int count = 0;
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = txtbxMessage.Text;
            if (string.IsNullOrEmpty(userMessage))
            { MessageBox.Show("Please enter a message before sending.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning); }
            else
            {
                AddMessage(userMessage, true);
                txtbxMessage.Clear();
                // Simulate bot response (you can replace this with actual chatbot logic)
                string botResponse = $"You said: {userMessage}";
                AddMessage(botResponse, false);
            }

            count++;
            lblcount.Content = count.ToString();
        }


        private void AddMessage(string message, bool isUser)
        {
            Border bubble = new Border
            {
                //simple if statement to determine the background color of the message bubble based on whether it's a user message or a bot message
                Background = isUser ? Brushes.LightGray : Brushes.DodgerBlue,
                CornerRadius = new CornerRadius(13),
                Padding = new Thickness(10),
                Margin = new Thickness(5),
                MaxWidth = 250,
                // if the message is from the user, align it to the right; otherwise, align it to the left
                HorizontalAlignment = isUser ? HorizontalAlignment.Right : HorizontalAlignment.Left
            };

            TextBlock text = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = isUser ? Brushes.White : Brushes.Black
            };

            bubble.Child = text;

            pnlChat.Children.Add(bubble);

            // Auto scroll
            ChatScrollViewer.ScrollToEnd();
        }
    }
}
