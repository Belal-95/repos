<%@  AutoEventWireup="true" CodeBehind="Task2.aspx.cs" Inherits="VodusTechnicalAssesement.Task2" %>

<!DOCTYPE html>

<html>
<head>
    <title>Task2</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var data = {
                "Data1": [
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "20% OFF WITH RM150 MINIMUM SPEND AT ZALORA",
                        "PromoDescription": "Use promo code UOB20Z upon checkout",
                        "StartDate": 43191,
                        "EndDate": 43555,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "25% OFF STOREWIDE WITH UOB CARDS",
                        "PromoDescription": "Discover the power of botanicals for a more beautiful you and enjoy 25% off when you make with a minimum purchase of RM180 with your UOB Card on Yves Rocher products using the promo code below:\r\n\r\nUse Code: YVES25\r\n\r\nOnly valid at Lazada Malaysia - Yves Rocher Official Store. Not exchangeable for cash.\r\n\r\nNot valid with any offer/promotion or discount item.",
                        "StartDate": 43447,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "6% OFF REEBONZ WITH UOB MASTERCARD",
                        "PromoDescription": "Enjoy extra 6% off daily all year round with UOB Mastercard\r\nTo redeem offer:\r\n\r\nVisit www.reebonz.com/my to shop now and enter coupon code MCMY6 at payment page.",
                        "Terms and Conditions": "Applicable to selected events and on selected merchandise only\r\nApplicable for full payment transactions only.\r\nPayment must be made with a UOB Mastercard card.",
                        "StartDate": 43101,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "ENJOY 10% OFF BIRKENSTOCK FOOTWEAR WITH UOB CARDS",
                        "PromoDescription": "Enjoy 10% off Birkenstock footwear with UOB Cards.\r\nOffer is only valid for normal-priced items at any Birkenstock outlets, only with UOB Cards.",
                        "StartDate": 43297,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "ENJOY 10% OFF FULL-PRICED ITEMS AT CLUB21 OUTLETS WITH UOB CARDS",
                        "PromoDescription": "Brands: 3.1 PHILLIP LIM|A|X ARMANI EXCHANGE|ARMANI JUNIOR|ARMANI/MARINA BAY|BAO BAO ISSEY MIYAKE|BLACKBARRETT BY NEIL BARRETT|BONPOINT|CK CALVIN KLEIN|CLUB21 FORUM|CLUB21 FOUR SEASONS|COMME des GARÇONS|DKNY|DOVER STREET MARKET SINGAPORE|DRIES VAN NOTEN|EMPORIO ARMANI|GIORGIO ARMANI|ISSEY MIYAKE|JIL SANDER|KENZO KIDS|KIDS21| LANVIN|MARNI|MSGM|MULBERRY |PAUL SMITH|PAUL SMITH JUNIOR|PLEATS PLEASE ISSEY MIYAKE |HOMME PLISSÉ ISSEY MIYAKE|PROENZA SCHOULER|PS PAUL SMITH |SACAI BY CLUB 21|T BY ALEXANDER WANG|STELLA McCARTNEY|STELLA McCARTNEY KIDS\r\n\r\nOffer is not valid in conjunction with other promotions, discounts or privileges\r\nOffer is not applicable at Comme des Garcons POCKET, Comme des Garcons PLAY pop-ups, Outlet by Club 21 and Pomellato\r\nOffer is not applicable on Comme des Garcons PLAY and Comme des Garcons BLACK products, on basic items and items on consignment",
                        "StartDate": 43405,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "ENJOY TRAVELICIOUS DEALS VIA SHOPBACK MALAYSIA",
                        "PromoDescription": "Malaysian Airlines, Expedia, Traveloka, KLOOK, Qatar Airways & Etihad Airways\r\nGet up to 7% Cash Back with your UOB Card when you travel and book your holiday with the following merchants via www.shopback.my/uob",
                        "Terms and Conditions": "Click through ShopBack before making a booking. Enable cookies on your device and make sure that the same device is used throughout. This promotion is only valid for bookings via desktop and mobile app.",
                        "StartDate": "2018-10-01\r\n",
                        "EndDate": "2018-12-31\r\n",
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "ENJOY BEAUTY REWARDS ON HERMO",
                        "PromoDescription": "Good news for beauty junkies!\r\nEnjoy exclusive discounts on skincare and makeup with a variety of products to choose when you shop online at HERMO:",
                        "Terms and Conditions": "Offers are valid from now until 31 December 2018.\r\n\r\nNot applicable for XOMO/OMO deals and/or in conjunction with other promotions where voucher exclusions apply.",
                        "StartDate": 43405,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "ENJOY UP TO 17% CASH BACK AT GUARDIAN, GIANT, COLD STORAGE, MERCATO AND JASONS FOOD HALL",
                        "PromoDescription": "\"ust spend with any UOB Card at the participating merchants to enjoy up to 17%** Cash Back.\r\n\r\nCash Back        Min. spend       Merchants                        Promotion Period\r\n     \r\nAdditional 10%*        RM150        Guardian                            16 July to 14 October 2018\r\n\r\nUp to 17%**               RM200       Selected grocery store(s)    16 July to 31 December 2018\"",
                        "Terms and Conditions": "*Applicable on weekdays from Monday, 12am until Friday, 11.59pm.\r\n\r\n**17% Cash Back is only applicable for UOB ONE Cardholders in Giant and Cold Storage only on weekends.",
                        "StartDate": 43297,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "EXCLUSIVE GIFT BY WAH CHAN CHINESE WEDDING JEWELLERY CENTRE",
                        "PromoDescription": "Enjoy an event of gold and glitter at Wah Chan Chinese Wedding Jewellery Centre",
                        "Terms and Conditions": "* Limited to first 100 UOB Cardholders, first come first serve.\r\n\r\n** Without any other purchase requirement. Limited to the first 50 UOB Cardholders, first come first serve.",
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "GET THE LATEST GALAXY NOTE9 AND MANY MORE AT 0% IPP",
                        "PromoDescription": "Pay only 11 months instalment when sign up for 0% 12 months Instalment Payment Plan\r\n\r\nTo order, please logon to https://3ex.com.my/uob\r\n\r\nFor product enquiries, please call tri-e marketing at 03-8076 1313\r\n\r\n(Monday - Friday : 9am - 6pm)",
                        "Terms and Conditions": "ENG  \r\n\r\nBM ",
                        "StartDate": 43344,
                        "EndDate": 43434,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "GET THE LATEST GADGET WITH 0% IPP",
                        "PromoDescription": "Pay only 11 months instalment when sign up for 0% 12 months Instalment Payment Plan\r\n\r\nTo purchase, download the order form below and fax to 03-7954 1727 or Email to sales@stc.net.my\r\n\r\nFor product enquiries, please call ST Connection at 03-79408900 (Monday - Friday : 9am - 6pm) excluding Public Holidays",
                        "Terms and Conditions": "ENG \r\n\r\nBM ",
                        "StartDate": 43344,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "S$10 OFF THE SHILLA DUTY FREE AT CHANGI AIRPORT",
                        "PromoDescription": "Enjoy S$10 off with minimum spend of S$200 with your UOB Cards at The Shilla Duty Free\r\n\r\nLocated at Changi Airport Terminal 1, 2, 3, 4 (Departure Transit Lounge, Departure Check-In Hall (Public Area) and Arrival Hall).",
                        "Terms and Conditions": "Valid with a minimum spend of S$200 in a single transaction.\r\nNot valid for CHANEL, LA MER, TOM FORD and JO MALONE products.\r\nGeneral terms and conditions apply.",
                        "StartDate": 43405,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "UP TO 20% OFF AT TRIUMPH",
                        "PromoDescription": "UOB Lady’s Card - 20% off min RM300, regular price items only\r\nCode: UOB-20\r\n20% OFF with purchase of RM300 regular priced items.\r\n\r\nAll other UOB Cards- 15% off min RM300, regular price items only \r\nCode: UOB-15\r\n15% OFF with purchase of RM300 regular priced items.",
                        "Terms and Conditions": "This promotion is only valid HERE\r\nFor this promotion, the payment must be made via UOB credit card.\r\nThis promotion is not valid for best buy or value buy items.\r\nThis promotion is not valid in conjunction with other promotions, offers, privileges, vouchers, loyalty program, privilege card(s) and mutually exclusive.",
                        "StartDate": 43405,
                        "EndDate": 43465,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    },
                    {
                        "Page": "https://vodus.com",
                        "PromoTitle": "YEAR END EXTRAVAGANZA",
                        "PromoDescription": "Spend a minimum of RM50 from 8 October 2018 until 10 February 2019 to stand a chance to win:\r\n\r\nGrand Prize\r\n\r\n1x BMW 530e Sport; or\r\n1x BMW 330e M Sport\r\n\r\nMonthly\r\n\r\n4x pairs of return ticket to Hawaii, USA\r\nWeekly\r\n\r\n18x 5-minute groceries sweep\r\nDaily\r\n\r\n126x 25,000 AirAsia BIG Points\r\nConsolation\r\n\r\n300x RM100 Petron fuel voucher\r\nClick here to enrol by entering your:\r\n\r\nmobile phone number; or\r\ncredit card number; or\r\nemail address",
                        "StartDate": 43381,
                        "EndDate": 43506,
                        "ImageURL": "https://rewards.vodus.com/Content/Images/vodus-rewards-logo.png"
                    }
                ]
            }




            $(data.Data1).each(function () {
                var output = "<ul><li>" + this.Page + "<br/>" + this.PromoTitle + "<br/>" + this.PromoDescription + "<br/>" + this.StartDate + "  -  " + this.EndDate + "<br/>" + this.ImageURL + "</li></ul>";
                $('#placeholder').append(output);
            });


            $(document).ready(function () {
                $("#search").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#placeholder li").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                    });
                });
            });
        });
    </script>
</head>
<body>
    <input type="search" name="search" id="search" value="" />
    <p><a href="/Default.aspx" class="btn btn-primary btn-lg">Back</a></p>
    <div id="placeholder"></div>

</body>
</html>