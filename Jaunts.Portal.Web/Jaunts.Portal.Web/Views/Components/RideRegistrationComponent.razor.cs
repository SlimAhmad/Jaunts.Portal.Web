// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Colors;
using Jaunts.Portal.Web.Client.Models.ContainerComponents;
using Jaunts.Portal.Web.Client.Models.RideViews;
using Jaunts.Portal.Web.Client.Models.RideViews.Exceptions;
using Jaunts.Portal.Web.Client.Models.RideRegistrationComponents.Exceptions;
using Jaunts.Portal.Web.Client.Services.Views.RideViews;
using Jaunts.Portal.Web.Client.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Views.Components
{
    public partial class RideRegistrationComponent : ComponentBase
    {
        [Inject]
        public IRideViewService RideViewService { get; set; }

        public ComponentState State { get; set; }
        public RideRegistrationComponentException Exception { get; set; }
        public RideView RideView { get; set; }
        public TextBoxBase RideNameTextBox { get; set; }
        public TextBoxBase RideDescriptionTextBox { get; set; }
        public TextBoxBase RideLocationTextBox { get; set; }
        public DropDownBase<RideViewStatus> RideStatusDropDown { get; set; }
        public DatePickerBase DatePicker { get; set; }
        public ButtonBase SubmitButton { get; set; }
        public LabelBase StatusLabel { get; set; }

        protected override void OnInitialized()
        {
            RideView = new RideView();
            State = ComponentState.Content;
        }

        public async void RegisterRideAsync()
        {
            try
            {
                ApplySubmittingStatus();
                await RideViewService.AddRideViewAsync(RideView);
                NavigateToRideSubmittedPage();
            }
            catch (RideViewValidationException studentViewValidationException)
            {
                string validationMessage =
                    studentViewValidationException.InnerException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (RideViewDependencyValidationException dependencyValidationException)
            {
                string validationMessage =
                    dependencyValidationException.InnerException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (RideViewDependencyException studentViewDependencyException)
            {
                string validationMessage =
                    studentViewDependencyException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (RideViewServiceException studentViewServiceException)
            {
                string validationMessage =
                    studentViewServiceException.Message;

                ApplySubmissionFailed(validationMessage);
            }
        }

        private void ApplySubmittingStatus()
        {
            StatusLabel.SetColor(Color.Black);
            StatusLabel.SetValue("Submitting ... ");
            RideNameTextBox.Disable();
            RideLocationTextBox.Disable();
            RideDescriptionTextBox.Disable();
            RideStatusDropDown.Disable();
            DatePicker.Disable();
            SubmitButton.Disable();
        }

        private void NavigateToRideSubmittedPage() =>
            RideViewService.NavigateTo("/submit");

        private void ApplySubmissionFailed(string errorMessage)
        {
            StatusLabel.SetColor(Color.Red);
            StatusLabel.SetValue(errorMessage);
            RideNameTextBox.Enable();
            RideLocationTextBox.Enable();
            RideDescriptionTextBox.Enable();
            RideStatusDropDown.Enable();
            DatePicker.Enable();
            SubmitButton.Enable();
        }
    }
}
