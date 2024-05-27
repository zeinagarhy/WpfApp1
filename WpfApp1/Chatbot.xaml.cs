using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class Chatbot : Window
    {
        private Dictionary<string, string> _knowledgeBase;

        public Chatbot()
        {
            InitializeComponent();
            InitializeKnowledgeBase();
        }

        private void InitializeKnowledgeBase()
        {
            _knowledgeBase = new Dictionary<string, string>
            {
                { "anxious", "It's understandable to feel anxious. Can you tell me more about what has been causing your anxiety?" },
                { "can't sleep", "Let's explore your worries one by one. What's the main thought that keeps you up at night?" },
                { "overwhelmed", "It sounds like you have a lot on your plate. Have you tried any relaxation techniques or time management strategies?" },
                // Add more predefined responses as needed
            };
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInputTextBox.Text.ToLower();
            if (!string.IsNullOrEmpty(userMessage))
            {
                AddMessageToChat("Doctor", userMessage, DateTime.Now.ToString("HH:mm"), "#9bb169", HorizontalAlignment.Left);
                string botResponse = GetBotResponse(userMessage);
                AddMessageToChat("Assistant", botResponse, DateTime.Now.ToString("HH:mm"), "#fe814b", HorizontalAlignment.Right);
                UserInputTextBox.Clear();
                UserInputTextBox.Focus();
            }
        }

        private void AddMessageToChat(string sender, string message, string timestamp, string color, HorizontalAlignment alignment)
        {
            ChatListBox.Items.Add(new ChatMessage
            {
                Sender = sender,
                Content = message,
                Timestamp = timestamp,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color)),
                Alignment = alignment
            });
            ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
        }

        private string GetBotResponse(string patientCase)
        {
            // Check if the patient case contains any CME-related keywords
            if (patientCase.Contains("cme"))
            {
                return "# Continuing Medical Education Opportunities\n\n" +
                       "- Upcoming webinar on the latest treatment guidelines for depression\n" +
                       "- Online course on integrating digital tools in mental health practice\n" +
                       "- Research update on the use of ketamine for treatment-resistant depression\n\n" +
                       "Let me know if you'd like more details on any of these CME opportunities.";
            }
            else if (patientCase.Contains("case study"))
            {
                return "## Recent Case Study: Cognitive-Behavioral Therapy for Social Anxiety Disorder\n\n" +
                       "*Patient Profile:*\n" +
                       "- Name: Sarah M.\n" +
                       "- Age: 28\n" +
                       "- Gender: Female\n" +
                       "- Occupation: Marketing Professional\n\n" +
                       "*Presenting Problem:*\n" +
                       "Sarah presented with symptoms of social anxiety, including avoidance of social situations, fear of public speaking, and excessive worry about being judged by others.\n\n" +
                       "*Treatment Approach:*\n" +
                       "Sarah underwent a 12-week cognitive-behavioral therapy (CBT) program, which included:\n" +
                       "- Cognitive restructuring to challenge and reframe negative thoughts\n" +
                       "- Exposure therapy to gradually confront feared social situations\n" +
                       "- Relaxation techniques, including deep breathing and progressive muscle relaxation\n\n" +
                       "*Outcome:*\n" +
                       "By the end of the treatment, Sarah reported a significant reduction in her anxiety symptoms and improved confidence in social settings. She successfully delivered a presentation at work without experiencing overwhelming anxiety and expressed a greater sense of control over her social anxiety.\n\n" +
                       "*Recommendations:*\n" +
                       "Based on Sarah's positive response to CBT, consider incorporating similar techniques with other patients presenting with social anxiety disorder. Emphasize the importance of regular practice and persistence in applying cognitive and behavioral strategies.\n\n" +
                       "*Further Reading:*\n" +
                       "- Hofmann, S. G., Asnaani, A., Vonk, I. J., Sawyer, A. T., & Fang, A. (2012). The Efficacy of Cognitive Behavioral Therapy: A Review of Meta-analyses. Cognitive Therapy and Research, 36(5), 427–440.\n" +
                       "- National Institute of Mental Health. (2019). Social Anxiety Disorder: More Than Just Shyness. https://www.nimh.nih.gov/health/publications/social-anxiety-disorder-more-than-just-shyness/index.shtml";
            }
            else if (patientCase.Contains("anxiety case"))
            {
                return "## Case Study: Managing Generalized Anxiety Disorder with Medication and Therapy\n\n" +
                       "*Patient Profile:*\n" +
                       "- Name: John D.\n" +
                       "- Age: 45\n" +
                       "- Gender: Male\n" +
                       "- Occupation: Software Engineer\n\n" +
                       "*Presenting Problem:*\n" +
                       "John presented with chronic worry, restlessness, and difficulty concentrating. He reported feeling anxious about various aspects of his life, including work and personal relationships.\n\n" +
                       "*Treatment Approach:*\n" +
                       "John's treatment plan included:\n" +
                       "- Medication: Prescribed an SSRI (Selective Serotonin Reuptake Inhibitor) to help reduce anxiety symptoms\n" +
                       "- Cognitive-Behavioral Therapy (CBT): Engaged in weekly sessions focused on identifying and challenging negative thought patterns and developing coping strategies\n" +
                       "- Lifestyle Modifications: Encouraged to incorporate regular physical exercise and mindfulness practices into his daily routine\n\n" +
                       "*Outcome:*\n" +
                       "Over a period of 6 months, John reported a significant decrease in anxiety symptoms. He found the combination of medication and therapy particularly effective in managing his anxiety. John also noted improvements in his concentration and overall quality of life.\n\n" +
                       "*Recommendations:*\n" +
                       "For patients presenting with generalized anxiety disorder, consider a comprehensive treatment plan that includes both pharmacological and psychological interventions. Regular follow-up is essential to monitor progress and make necessary adjustments.\n\n" +
                       "*Further Reading:*\n" +
                       "- Baldwin, D. S., Anderson, I. M., Nutt, D. J., Bandelow, B., Bond, A., Davidson, J. R., ... & Wittchen, H. U. (2014). Evidence-based pharmacological treatment of anxiety disorders, post-traumatic stress disorder and obsessive-compulsive disorder: A revision of the 2005 guidelines from the British Association for Psychopharmacology. Journal of Psychopharmacology, 28(5), 403-439.\n" +
                       "- American Psychological Association. (2017). Clinical Practice Guideline for the Treatment of Posttraumatic Stress Disorder (PTSD) in Adults. https://www.apa.org/ptsd-guideline/ptsd.pdf";
            }
            else
            {
                // Default response for non-CME-related cases
                return "I'm sorry, I don't have enough information to provide a response. Can you please rephrase your question or provide more details?";
            }
        }
    }

    // Class representing a chat message
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }
        public SolidColorBrush Background { get; set; }
        public HorizontalAlignment Alignment { get; set; }
    }
}