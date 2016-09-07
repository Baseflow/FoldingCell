using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Ramotion.Foldingcell;

namespace Sample
{
    public class FoldingCellListAdapter : ArrayAdapter<Item> //, View.IOnClickListener
    {
        private HashSet<int> unfoldedIndexes = new HashSet<int>();
        private View.IOnClickListener defaultRequestBtnClickListener;

        public FoldingCellListAdapter(Context context, IList<Item> objects) : base(context, 0, objects)
        {
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // get item for selected view
            Item item = GetItem(position);
            // if cell is exists - reuse it, if not - create the new one from resource
            FoldingCell cell = (FoldingCell)convertView;
            ViewHolder viewHolder;
            if (cell == null)
            {
                viewHolder = new ViewHolder();
                LayoutInflater vi = LayoutInflater.From(Context);
                cell = (FoldingCell)vi.Inflate(Resource.Layout.cell, parent, false);
                // binding view parts to view holder
                viewHolder.price = (TextView)cell.FindViewById(Resource.Id.title_price);
                viewHolder.time = (TextView)cell.FindViewById(Resource.Id.title_time_label);
                viewHolder.date = (TextView)cell.FindViewById(Resource.Id.title_date_label);
                viewHolder.fromAddress = (TextView)cell.FindViewById(Resource.Id.title_from_address);
                viewHolder.toAddress = (TextView)cell.FindViewById(Resource.Id.title_to_address);
                viewHolder.requestsCount = (TextView)cell.FindViewById(Resource.Id.title_requests_count);
                viewHolder.pledgePrice = (TextView)cell.FindViewById(Resource.Id.title_pledge);
                viewHolder.contentRequestBtn = (TextView)cell.FindViewById(Resource.Id.content_request_btn);
                cell.Tag = viewHolder;
            }
            else {
                // for existing cell set valid valid state(without animation)
                if (unfoldedIndexes.Contains(position))
                {
                    cell.Unfold(true);
                }
                else {
                    cell.Fold(true);
                }
                viewHolder = (ViewHolder)cell.Tag;
            }

            // bind data from selected element to view through view holder
            viewHolder.price.Text = item.getPrice();
            viewHolder.time.Text = item.getTime();
            viewHolder.date.Text = item.getDate();
            viewHolder.fromAddress.Text = item.getFromAddress();
            viewHolder.toAddress.Text = item.getToAddress();
            viewHolder.requestsCount.Text = item.getRequestsCount().ToString();
            viewHolder.pledgePrice.Text = item.getPledgePrice();

            // set custom btn handler for list item from that item
            if (item.getRequestBtnClickListener() != null)
            {
                viewHolder.contentRequestBtn.SetOnClickListener(item.getRequestBtnClickListener());
            }
            else {
                // (optionally) add "default" handler if no handler found in item
                viewHolder.contentRequestBtn.SetOnClickListener(defaultRequestBtnClickListener);
            }

            return cell;
        }

        // simple methods for register cell state changes
        public void registerToggle(int position)
        {
            if (unfoldedIndexes.Contains(position))
                registerFold(position);
            else
                registerUnfold(position);
        }

        public void registerFold(int position)
        {
            unfoldedIndexes.Remove(position);
        }

        public void registerUnfold(int position)
        {
            unfoldedIndexes.Add(position);
        }

        public View.IOnClickListener getDefaultRequestBtnClickListener()
        {
            return defaultRequestBtnClickListener;
        }

        public void setDefaultRequestBtnClickListener(View.IOnClickListener defaultRequestBtnClickListener)
        {
            this.defaultRequestBtnClickListener = defaultRequestBtnClickListener;
        }

        // View lookup cache
        private class ViewHolder : Java.Lang.Object
        {
            public TextView price { get; set; }
            public TextView contentRequestBtn { get; set; }
            public TextView pledgePrice { get; set; }
            public TextView fromAddress { get; set; }
            public TextView toAddress { get; set; }
            public TextView requestsCount { get; set; }
            public TextView date { get; set; }
            public TextView time { get; set; }
        }
    }
}

