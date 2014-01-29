// ------------------------------------------------------------------
// Pitsini Suwandechochai
// Description: sturcture of product class refer to TravelExperts DB
// ------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Product
{
    // parameters
    private int bookingId;
    private string destination;
    private string description;
    private string bookingNo;
    private double itineraryNo;
    private DateTime tripStart;
    private DateTime tripEnd;
    private decimal basePrice;
    private int productId;
    private string productName;

    
    // properties to access to parameters
    public int BookingId
    {
        get { return bookingId; }
        set { bookingId = value; }
    }
    public string Destination
    {
        get { return destination; }
        set { destination = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public string BookingNo
    {
        get { return bookingNo; }
        set { bookingNo = value; }
    }
    public double ItineraryNo
    {
        get { return itineraryNo; }
        set { itineraryNo = value; }
    }
    public DateTime TripStart
    {
        get { return tripStart; }
        set { tripStart = value; }
    }
    public DateTime TripEnd
    {
        get { return tripEnd; }
        set { tripEnd = value; }
    }
    public decimal BasePrice
    {
        get { return basePrice; }
        set { basePrice = value; }
    }
    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }      
    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }

    // blank constructor
    public Product()    {    }

    // constructor
    public Product(int newBookingId, string newDestination, string newDescription, string newBookingNo,
        double newItineraryNo, DateTime newTripStart, DateTime newTripEnd, decimal newBasePrice,
                    int newProductId, string newProductName)
    {
        BookingId = newBookingId;
        Destination = newDestination;
        Description = newDescription;
        BookingNo = newBookingNo;
        ItineraryNo = newItineraryNo;
        TripStart = newTripStart;
        TripEnd = newTripEnd;
        BasePrice = newBasePrice;
        ProductId = newProductId;
        ProductName = newProductName;
    }
}