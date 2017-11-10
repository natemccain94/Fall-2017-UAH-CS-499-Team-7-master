﻿using System;
namespace test2
{
    public class ClosingForms
    {
        public ClosingForms()
        {
        }

        #region Closing Settlement Statement String
        private string ClosingForm = string.Concat(
            "                 Closing Settlement Statement\n\n",
            "Seller: <customer selling>          Buyer: <customer buying>\n\n",
            "Seller: <realtor name>              Buyer: <customer realtor>\n\n",
            "Property Address: <Street>\n\n",
            "City: <City>            State: <State>        Zip: <Zip>\n\n",
            "Total Price: <Listing Price>\n\n",
            "  ------------------------------------------------------------------\n",
            "| I/We certify that the contents hereof are true and correct.      |\n",
            "|                                                                  |\n",
            "| Sellers:                                                         |\n",
            "| Print Name: <Customer Selling>       SS#:___________________     |\n",
            "| Signature:____________________       Date:__________________     |\n",
            "| Print Name: <Realtor Selling>        SS#:___________________     |\n",
            "| Signature:____________________       Date:__________________     |\n",
            " ------------------------------------------------------------------\n\n\n",
            "  ------------------------------------------------------------------\n",
            "| I/We certify that the contents hereof are true and correct.      |\n",
            "|                                                                  |\n",
            "| Buyers:                                                          |\n",
            "| Print Name: <Customer Buying>        SS#:___________________     |\n",
            "| Signature:____________________       Date:__________________     |\n",
            "| Print Name: <Realtor Buying>         SS#:___________________     |\n",
            "| Signature:____________________       Date:__________________     |\n",
            " ------------------------------------------------------------------\n");
        #endregion
        #region Agreement to Purchase Real Estate String
        private string AgreementToPurchaseRealEstate = string.Concat(
            "AGREEMENT TO PURCHASE REAL ESTATE\n\n",
            "The undersigned (herein \"Purchaser\") hereby offers to purchase from the owner (herein \"Seller\") the real estate\n",
            "located at <Street> in the city of <City>, State of <State>, the legal description of which is:\n",
            "<listing description>",
            "upon the following terms and conditions:\n\n",
            "1. Purchase Price and Conditions of Payment\n",
            "The purchase price shall be <Listing Price> to be paid in accordance with subparagraph _________, below:\n",
            "A: Cash. The purchase price shall be paid in its entirety in cash at the time of closing the sale.\n\n",
            "B: Cash Subject to New Mortgage. The purchase price shall be paid in cash at the time of closing the sale\n",
            "subject, however, to Purchaser's ability to obtain a first mortgage loan within ______ days after the\n",
            "acceptance of this offer by Seller in the amount of $_________________, payable in not less than\n",
            "_________ monthly installments, including interest at a rate not to exceed ___________% financing. If\n",
            "such financing cannot be obtained within the time specified above then either Purchaser or Seller may terminate\n",
            "this agreement and any earnest money deposited by Purchaser will be promptly refunded.\n\n",
            "C: Cash Subject to Existing Mortgage. The purchase price shall be paid in cash at the time of the\n",
            "closing of the sale after deducting from the purchase price the then outstanding balance due and owing under the\n",
            "existing mortgage in favor of ________________, dated _______________, 20__, in the original amount of $_______________;\n",
            "of such mortgage debt is approximately $__________________ as of ___________________, 20__.\n\n",
            "D: Cash With Assumption of Existing Mortgage. The purchase price shall be paid in cash at the time of the\n",
            "closing of the sale after deducting from the purchase price the then outstanding balance due and owing under the\n",
            "existing mortgage in favor of ___________________, dated _________________, 20__, having a present balance of\n",
            "approximately $___________________, as of _________________, 20__, which the purchaser hereby assumes and agrees\n",
            "to pay in accordance with its terms and to perform all of its provisions; purchaser shall pay any and all payments\n",
            "coming due after the closing of the sale. Any transfer fees required by the mortgage shall be\n",
            "paid by _____________________.\n\n",
            "E: Sale by Land Contract. The purchase price shall be paid in accordance with the certain land contract\n",
            "attached hereto and incorporated into this contract by this reference. The down payment to be made at the time of\n",
            "closing this sale shall be $___________________ and the balance of $________________ shall be paid at the rate of\n",
            "__________% per annum.\n\n\n",
            "2. Earnest Money Deposit\n\n",
            "As earnest money Purchaser deposits $_______________ with the broker which shall be applied to the\n",
            "purchase price at the time of closing the sale. In the event thtat this offer is not accepted by Seller this earnest\n",
            "money deposit shall be promptly refunded to Purchaser by the broker. In the event that this offer is accepted by\n",
            "Seller and Purchaser shall fail to perform the terms of this agreement the earnest money deposit shall be forfeited\n",
            "as and for liquidated damages suffered by Seller. Seller is not, however, precluded from asserting any other legal\n",
            "or equitable remedy, which may be available to enforce this agreement.\n\n\n",
            "3. Real Estate Taxes, Assessments, and Adjustments\n\n",
            "Real Estate Taxes accrued against the property shall be prorated through the date of closing the sale and Seller\n",
            "shall pay all taxes allocated to the property through that date of acceptance of this offer to purchase. Rents, if any,\n",
            "shall be prorated through the date of closing and all rent deposits shall be transferred to Purchaser. Existing\n",
            "casualty insurance shall be canceled/prorated through the date of closing.\n\n\n",
            "4. Title to the Property\n\n",
            "Seller shall provide purchaser prior to the closing and promptly after the acceptance of this offer, at Seller's\n",
            "expense and at Seller's option an abstract of title to the property brought down to date or an owner's policy of title\n",
            "insurance in an amount equal to the purchase price, said abstract of policy to show marketable or insurable title to\n",
            "the real estate in the name of Seller subject only to easements, zoning and restrictions of record and free and clear\n",
            "of all other liens and encumbrances except as stated in this offer. If the abstract or title policy fails to show\n",
            "marketable or insurable title in Seller a reasonable time shall be permitted to cure or correct defects. Seller shall\n",
            "convey title to Purchaser at the time of closing by a good and sufficient general warranty deed free and clear of all\n",
            "liens and encumbrances except as otherwise provided in this offer and subject to easements, zoning and\n",
            "restriction of record.\n\n\n",
            "5. Possesion of the Property\n\n",
            "Purchaser shall be given possession of the property on ________________, 20__. A failure on the part of Seller\n",
            "to transfer possession as specified will not make Seller a tenant of Purchaser, but in such event Seller shall pay to\n",
            "Purchaser $_____________ per day as damages for breach of contract and not as rent. All other\n",
            "remedies, which Purchaser may have under law, are reserved to Purchaser.\n\n\n",
            "6. Risk of Loss\n\n",
            "The risk of loss by destruction or damage to the property by fire or otherwise prior to the closing of the sale is that\n",
            "of Seller. If all or a substantial portion of the improvements on the property are destroyed or damaged prior to the\n",
            "closing and transfer of title this agreement shall be void able at Purchaser's option and in the event Purchaser\n",
            "elects to avoid this agreement the earnest money deposited shall be promptly refunded.\n\n\n",
            "7. Improvements and Fixtures Included\n\n",
            "This offer to purchase includes all improvements, buildings and fixtures presently on the real estate including but\n",
            "not limited to electrical, gas, heating, air conditioning, plumbing equipment, built-in appliances, hot water heaters,\n",
            "screens, storm windows, doors, Venetian blinds, drapery hardware, awnings, attached carpeting, radio, television\n",
            "antennas, trees, shrubs, flowers, fences and \n",
            "_____________________________________________________________________________________________________________\n",
            "_____________________________________________________________________________________________________________\n",
            "_____________________________________________________________________________________________________________\n",
            "_____________________________________________________________________________________________________________\n",
            "_____________________________________________________________________________________________________________\n\n\n",
            "8. General Conditions\n\n",
            "It is expressly agreed that this agreement to purchase real estate includes the entire agreement of Purchaser and\n",
            "Seller. This agreement shall be binding upon the heirs, personal representatives, successors and assigns of both\n",
            "Purchaser and Seller. This agreement shall be interpreted and enforced in accordance with the laws of the State\n",
            "of <State>.\n\n\n",
            "9. Special Conditions\n\n",
            "_____________________________________________________________________________________________________________\n",
            "_____________________________________________________________________________________________________________\n",
            "_____________________________________________________________________________________________________________\n\n\n",
            "10. Time for Acceptance and Closing\n\n",
            "This offer is void if not accepted by Seller in writing on or before ____________________ A.M./P.M. of\n",
            "the ____________________ day of _____________________, 20__.\n\n",
            "Closing of the sale shall take place ___________________ days after Purchaser's receipt of an abstract showing\n",
            "marketable title in Sellor or title insurance binder showing insurable title in Seller.\n\n",
            "This offer is made at ______________________________, State of <State>, this\n",
            "____________________ day of _______________________, 20__.\n\n\n\n",
            "                                                                              ________________________________\n",
            "                                                                                                   (PURCHASER)\n",
            "                                                                              ________________________________\n",
            "                                                                                                   (PURCHASER)\n\n\n\n",
            "Acceptance by Seller\n\n",
            "The foregoing offer to purchase real estate is hereby accepted in accordance with the terms and conditions specified\n",
            "above. The undersigned hereby aggrees to pay a brokerage fee of $__________________ to \n",
            "<Realtor Selling>, broker, in accordance with the existing listing contract.\n\n",
            "Dated this __________________________ day of _________________________, 20__.\n\n\n\n",
            "                                                                              ________________________________\n",
            "                                                                                                      (SELLER)\n",
            "                                                                              ________________________________\n",
            "                                                                                             (REALTOR SELLING)\n\n\n\n");
        #endregion

        #region Request for Repairs String
        private string RequestForRepairs = string.Concat(
        "REQUEST FOR REPAIR NO. __________\n",
        "(Or other Corrective Action)\n\n",
            "Date Prepared: __________________\n",
            "In accordance with the terms and conditions of the: Purchase Agreement or _Other_______________________\n",
            "(\"Agreement\"), dated ________________, on property known as <Street>, <City>, <State>  <Zip>\n",
            "between __________________________ (\"BUYER\"), and __________________________ (\"SELLER\").\n\n\n",
            "BUYER REQUEST: \n\n",
            "1. (a) __ Buyer requests that Seller, prior to final verification of condition, repair or take the other\n",
            "specified action for each item listed below or __ on the attached list dated _______________:\n",
            "__________________________________________________________________________________________________________\n",
            "__________________________________________________________________________________________________________\n",
            "__________________________________________________________________________________________________________\n",
            "__________________________________________________________________________________________________________\n",
            "__________________________________________________________________________________________________________\n",
            "__________________________________________________________________________________________________________\n",
            "__________________________________________________________________________________________________________\n",
            "__________________________________________________________________________________________________________\n",
            "__________________________________________________________________________________________________________\n",
            "   (b) (i) __ SECTION 1: Buyer requests Seller pay to have Section 1 work completed as specified in the attached\n",
            "                      Pest Control Report dated ______________ prepared by _________________________________.\n",
            "       (ii) __ SECTION 2: Buyer requests Seller pay to have Section 2 work completed as specified in the attached\n",
            "                       Pest Control Report dated ______________ prepared by _________________________________.\n",
            "       (iii) If Buyer requests either Section 1 or Section 2 work above, Seller shall, no later than 5 (or ____)\n",
            "          Days Prior to Close of Escrow, Deliver to Buyer a written pest control certification showing the\n",
            "          corrective work has been completed.\n",
            "   (c) __ Buyer requests that Seller credit Buyer $_______________ in lieu of repairs at Close of Escrow.\n",
            "      (Note: Credits need to be disclosed to Buyer's lender and total contractual credits may be limited pursuant\n",
            "      to the Agreement. Total credit amount may not be enough to remedy all defects or repairs.)",
            "   (d) __ Buyer requests that Seller reduce the purchase price to $_____________________________________________.\n\n\n",
            "2. A copy of the following inspection or other report is attached.\n",
            "  __ ____________________________________________________     __ ____________________________________________________\n",
            "                                            (REPORT NAME)                                               (REPORT NAME)\n",
            "  __ ____________________________________________________     __ ____________________________________________________\n",
            "                                            (REPORT NAME)                                               (REPORT NAME)\n\n\n",
            "Buyer ____________________________________________________ Date _____________________\n",
            "Buyer ____________________________________________________ Date _____________________\n\n\n",
            "SELLER RESPONSE:\n\n",
            "__ Seller agrees to all of Buyer's Request provided in writing (seel below) (i) Buyer removes the physical inspection\n",
            "contingency, (ii) __ Buyer removes those contingencies identified on the attached forms which must be signed by Buyer,\n",
            " and (iii) Buyer releases Seller from any loss, liability, expense, claim or cause of action regarding the disclosed\n",
            "condition of the Property (\"Release\").\n\n",
            "__ Seller does NOT agree to any of Buyer's requests.\n",
            "__ Seller responds to Buyer's request on the attached form(s).\n\n",
            "Seller: ____________________________________________________ Date _____________________\n",
            "Seller: ____________________________________________________ Date _____________________\n",
            "______________________________________________________________________________________________________________________\n\n",
            "If Seller agrees to all of Buyer's request, Buyer hereby removes the physical inspection contingencies and those\n",
            "identified on the attached form(s) signed by Buyer and agrees to the above Release.\n\n",
            "Buyer ____________________________________________________ Date _____________________\n",
            "Buyer ____________________________________________________ Date _____________________\n\n\n\n",
            " __________________________________________________________ \n",
            "|                                                          |\n",
            "| Reviewd by ____________________ Date _________________   |\n",
            "|                                                          |\n",
            "|__________________________________________________________|\n");

        #endregion
    }
}
