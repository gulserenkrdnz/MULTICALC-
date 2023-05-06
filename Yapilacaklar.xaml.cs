using System.Collections.ObjectModel;

namespace Odev1;

public partial class Yapilacaklar : ContentPage
{
    ObservableCollection<Task> tasks = new ObservableCollection<Task>();

    public class Task
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateAdded { get; set; }

        public Task(string description)
        {
            Description = description;
            IsComplete = false;
            DateAdded = DateTime.Now;
        }
    }


    public Yapilacaklar()
    {
        InitializeComponent();
        taskList.ItemsSource = tasks;
       
    }
   
    async void OnAddClicked(object sender, EventArgs e)
    {
        string taskDescription = await DisplayPromptAsync("Yeni Görev", "Görev Tanýmla:");
        tasks.Add(new Task(taskDescription));
    }

    void OnViewCellBindingContextChanged(object sender, EventArgs e)
    {
        if (sender is ViewCell viewCell)
        {
            var editButton = viewCell.FindByName<ImageButton>("editButton");
            if (editButton != null)
            {
                editButton.BindingContext = viewCell.BindingContext;
            }
        }
    }

    async void OnTaskTapped(object sender, EventArgs e)
    {
        var task = (sender as ImageButton)?.BindingContext as Task;
        if (task != null)
        {
            string newDescription = await DisplayPromptAsync("Görevi Düzenle", "Yeni Görev Tanýmý:", initialValue: task.Description);
            if (!string.IsNullOrEmpty(newDescription))
            {
                task.Description = newDescription;
                taskList.SelectedItem = null;
                if (!string.IsNullOrEmpty(newDescription))
                {
                    
                    int index = tasks.IndexOf(task);
                    
                    task.Description = newDescription;
                    
                    tasks[index] = task;

                    taskList.SelectedItem = null;
                }

            }
        }
    }
    void OnTaskChecked(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = (CheckBox)sender;
        if (checkBox.BindingContext is Task task)
        {
           
            task.IsComplete = e.Value;
         
            taskList.SelectedItem = null;
        }
    }


    void OnDeleteClicked(object sender, EventArgs e)
    {
        var task = (sender as ImageButton)?.BindingContext as Task;
        if (task != null)
        {
            tasks.Remove(task);
        }
    }



}