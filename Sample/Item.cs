using System;
using System.Collections.Generic;
using Android.Views;

namespace Sample
{
    public class Item
    {
        private string price;
        private string pledgePrice;
        private string fromAddress;
        private string toAddress;
        private int requestsCount;
        private string date;
        private string time;

        private View.IOnClickListener requestBtnClickListener;

        public Item()
        {
        }

        public Item(string price, string pledgePrice, string fromAddress, string toAddress, int requestsCount, string date, string time)
        {
            this.price = price;
            this.pledgePrice = pledgePrice;
            this.fromAddress = fromAddress;
            this.toAddress = toAddress;
            this.requestsCount = requestsCount;
            this.date = date;
            this.time = time;
        }

        public string getPrice()
        {
            return price;
        }

        public void setPrice(string price)
        {
            this.price = price;
        }

        public string getPledgePrice()
        {
            return pledgePrice;
        }

        public void setPledgePrice(string pledgePrice)
        {
            this.pledgePrice = pledgePrice;
        }

        public string getFromAddress()
        {
            return fromAddress;
        }

        public void setFromAddress(string fromAddress)
        {
            this.fromAddress = fromAddress;
        }

        public string getToAddress()
        {
            return toAddress;
        }

        public void setToAddress(string toAddress)
        {
            this.toAddress = toAddress;
        }

        public int getRequestsCount()
        {
            return requestsCount;
        }

        public void setRequestsCount(int requestsCount)
        {
            this.requestsCount = requestsCount;
        }

        public string getDate()
        {
            return date;
        }

        public void setDate(string date)
        {
            this.date = date;
        }

        public string getTime()
        {
            return time;
        }

        public void setTime(string time)
        {
            this.time = time;
        }

        public View.IOnClickListener getRequestBtnClickListener()
        {
            return requestBtnClickListener;
        }

        public void setRequestBtnClickListener(View.IOnClickListener requestBtnClickListener)
        {
            this.requestBtnClickListener = requestBtnClickListener;
        }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;

            Item item = (Item)o;

            if (requestsCount != item.requestsCount) return false;
            if (price != null ? !price.Equals(item.price) : item.price != null) return false;
            if (pledgePrice != null ? !pledgePrice.Equals(item.pledgePrice) : item.pledgePrice != null)
                return false;
            if (fromAddress != null ? !fromAddress.Equals(item.fromAddress) : item.fromAddress != null)
                return false;
            if (toAddress != null ? !toAddress.Equals(item.toAddress) : item.toAddress != null)
                return false;
            if (date != null ? !date.Equals(item.date) : item.date != null) return false;
            return !(time != null ? !time.Equals(item.time) : item.time != null);
        }

        public override int GetHashCode()
        {
            int result = price != null ? price.GetHashCode() : 0;
            result = 31 * result + (pledgePrice != null ? pledgePrice.GetHashCode() : 0);
            result = 31 * result + (fromAddress != null ? fromAddress.GetHashCode() : 0);
            result = 31 * result + (toAddress != null ? toAddress.GetHashCode() : 0);
            result = 31 * result + requestsCount;
            result = 31 * result + (date != null ? date.GetHashCode() : 0);
            result = 31 * result + (time != null ? time.GetHashCode() : 0);
            return result;
        }

        /**
         * @return List of elements prepared for tests
         */
        public static List<Item> getTestingList()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item("$14", "$270", "W 79th St, NY, 10024", "W 139th St, NY, 10030", 3, "TODAY", "05:10 PM"));
            items.Add(new Item("$23", "$116", "W 36th St, NY, 10015", "W 114th St, NY, 10037", 10, "TODAY", "11:10 AM"));
            items.Add(new Item("$63", "$350", "W 36th St, NY, 10029", "56th Ave, NY, 10041", 0, "TODAY", "07:11 PM"));
            items.Add(new Item("$19", "$150", "12th Ave, NY, 10012", "W 57th St, NY, 10048", 8, "TODAY", "4:15 AM"));
            items.Add(new Item("$5", "$300", "56th Ave, NY, 10041", "W 36th St, NY, 10029", 0, "TODAY", "06:15 PM"));
            return items;
        }
    }
}

