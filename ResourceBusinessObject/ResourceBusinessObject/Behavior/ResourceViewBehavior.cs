using Syncfusion.Maui.Scheduler;

namespace ResourceBusinessObject
{
    internal class ResourceViewBehavior : Behavior<ContentPage>
    {
        /// <summary>
        /// the scheduler object.
        /// </summary>
        private SfScheduler? scheduler;

        /// <summary>
        /// Begins when the behavior attached to the view 
        /// </summary>
        /// <param name="bindable">bindable value.</param>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.scheduler = bindable.FindByName<SfScheduler>("Scheduler");
            this.scheduler.ViewChanged += this.OnSchedulerViewChanged;
        }


        /// <summary>
        /// Invokes on scheduler view type changed.
        /// </summary>
        /// <param name="sender">The scheduler object.</param>
        /// <param name="e">The scheduler view changed event args.</param>
        private void OnSchedulerViewChanged(object? sender, SchedulerViewChangedEventArgs e)
        {
            if (e.OldView == e.NewView || this.scheduler == null)
            {
                return;
            }

            if (e.NewView == SchedulerView.TimelineMonth || e.NewView == SchedulerView.TimelineDay)
            {
                this.scheduler.TimelineView.TimeIntervalWidth = 150;
            }
            else
            {
                this.scheduler.TimelineView.TimeIntervalWidth = 50;
            }
        }

        /// <summary>
        /// Begins when the behavior detaching from the view. 
        /// </summary>
        /// <param name="bindable">bindable value.</param>
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.scheduler != null)
            {
                this.scheduler.ViewChanged -= this.OnSchedulerViewChanged;
                this.scheduler = null;
            }
        }
    }
}
