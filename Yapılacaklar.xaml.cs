namespace GorselProgramlamaOdev21010310066;

public partial class Yapılacaklar : ContentPage
{
    int count = 0;
    private List<StackLayout> todoItemStacks = new List<StackLayout>();
    private bool isCancelled;
    private List<CheckBox> checkedCheckBoxes = new List<CheckBox>();
    public Yapılacaklar()
	{
		InitializeComponent();
	}
    private async void OnEditTapped(object sender, EventArgs e)
    {
        Image editImage = (Image)sender;
        StackLayout parentStack = (StackLayout)editImage.Parent;

        Label label = parentStack.Children.OfType<Label>().FirstOrDefault();
        if (label != null)
        {
            string editedText = await DisplayPromptAsync("Düzenle", "Yazıyı düzenleyin", "Tamam", "İptal", null, -1, Keyboard.Default, label.Text);
            if (!string.IsNullOrEmpty(editedText))
            {
                label.Text = editedText;
            }
        }
    }

    private async void OnDeleteTapped(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Sil", "Bu maddeyi silmek istediğinizden emin misiniz?", "Evet", "Hayır");
        if (answer)
        {
            Image deleteImage = (Image)sender;
            StackLayout parentStack = (StackLayout)deleteImage.Parent;

            todoItemLayout.Children.Remove(parentStack);
            todoItemStacks.Remove(parentStack);
        }
    }

    private async void OnAddButtonTapped(object sender, EventArgs e)
    {
        StackLayout formLayout = CreateTodoForm();

        bool result = await DisplayFormAsync(formLayout, "Yeni Madde Ekle", async () =>
        {
            
            string newLabelText = ((Entry)formLayout.Children[1]).Text;
            string newDetailText = ((Entry)formLayout.Children[3]).Text;
            DateTime newDateTime = ((DatePicker)((StackLayout)formLayout.Children[5]).Children[0]).Date + ((TimePicker)((StackLayout)formLayout.Children[5]).Children[1]).Time;

            if (!string.IsNullOrEmpty(newLabelText))
            {
                
                CheckBox checkBox = new CheckBox();

                

                checkBox.CheckedChanged += OnCheckBoxCheckedChanged;



                StackLayout newTodoStack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal, 
                    Margin = new Thickness(0, 10)
                };

                
                newTodoStack.Children.Add(checkBox);

                Label newLabel = new Label
                {
                    Text = newLabelText,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 20,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                newTodoStack.Children.Add(newLabel);

                Label newDetailLabel = new Label
                {
                    Text = newDetailText,
                    FontSize = 16,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                newTodoStack.Children.Add(newDetailLabel);

                Label newDateTimeLabel = new Label
                {
                    Text = newDateTime.ToString(),
                    FontSize = 14,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                newTodoStack.Children.Add(newDateTimeLabel);

                StackLayout actionsLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.End
                };

                Image editImage = new Image
                {
                    Source = "ekle.png",
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0),
                    HeightRequest = 24,
                    WidthRequest = 24
                };
                editImage.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(async () => await EditTodoItem(newTodoStack))
                });
                actionsLayout.Children.Add(editImage);

                Image deleteImage = new Image
                {
                    Source = "del.png",
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(10, 0, 0, 0),
                    HeightRequest = 24,
                    WidthRequest = 24
                };
                deleteImage.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(async () =>
                    {
                        bool answer = await DisplayAlert("Sil", "Bu maddeyi silmek istediğinizden emin misiniz?", "Evet", "Hayır");
                        if (answer)
                        {
                            todoItemLayout.Children.Remove(newTodoStack);
                        }
                    })
                });
                actionsLayout.Children.Add(deleteImage);

                newTodoStack.Children.Add(actionsLayout);

                todoItemLayout.Children.Add(newTodoStack);
            }
        });

        
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkbox = (CheckBox)sender;
        if (checkbox.IsChecked)
        {
            
            checkedCheckBoxes.Add(checkbox);
        }
        else
        {
            
            checkedCheckBoxes.Remove(checkbox);
        }
    }


    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        DeleteCheckedCheckBoxes();
    }
    private void DeleteCheckedCheckBoxes()
    {
        foreach (var checkbox in checkedCheckBoxes)
        {
            
            var parentStack = (StackLayout)checkbox.Parent;
            todoItemLayout.Children.Remove(parentStack);
            todoItemStacks.Remove(parentStack);
        }

        
        checkedCheckBoxes.Clear();
    }


    private async Task EditTodoItem(StackLayout todoStack)
    {
        Label editLabel = (Label)todoStack.Children[0];
        Label editDetailLabel = (Label)todoStack.Children[1];
        Label editDateTimeLabel = (Label)todoStack.Children[2];

        StackLayout formLayout = CreateTodoForm(editLabel.Text, editDetailLabel.Text, editDateTimeLabel.Text);

        bool result = await DisplayFormAsync(formLayout, "Maddeyi Düzenle", async () =>
        {
            
            editLabel.Text = ((Entry)formLayout.Children[1]).Text;
            editDetailLabel.Text = ((Entry)formLayout.Children[3]).Text;
            DateTime newDateTime = ((DatePicker)((StackLayout)formLayout.Children[5]).Children[0]).Date + ((TimePicker)((StackLayout)formLayout.Children[5]).Children[1]).Time;

            editDateTimeLabel.Text = newDateTime.ToString();
        });
    }

    private StackLayout CreateTodoForm(string title = "", string detail = "", string dateTime = "")
    {
        return new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Children =
            {
                new Label { Text = "Görev Başlığı", FontAttributes = FontAttributes.Bold },
                new Entry { Text = title },

                new Label { Text = "Detay", FontAttributes = FontAttributes.Bold },
                new Entry { Text = detail },

                new Label { Text = "Tarih ve Saat", FontAttributes = FontAttributes.Bold },
                new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        new DatePicker { Date = DateTime.Today },
                        new TimePicker { Time = TimeSpan.FromHours(DateTime.Now.Hour) }
                    }
                }
            }
        };
    }

    private async Task<bool> DisplayFormAsync(StackLayout formLayout, string title, Func<Task> onConfirm)
    {
        bool isConfirmed = false;
        var confirmButton = new Button { Text = "Tamam" };
        confirmButton.Clicked += async (sender, args) =>
        {
            await onConfirm();
            isConfirmed = true;
            await Application.Current.MainPage.Navigation.PopModalAsync();
        };

        var cancelButton = new Button { Text = "İptal" };
        cancelButton.Clicked += async (sender, args) =>
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        };

        var modalStack = new StackLayout
        {
            Children =
            {
                new ScrollView { Content = formLayout },
                new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { confirmButton, cancelButton }
                }
            }
        };

        await Application.Current.MainPage.Navigation.PushModalAsync(new ContentPage { Content = modalStack });

        return isConfirmed;
    }

}