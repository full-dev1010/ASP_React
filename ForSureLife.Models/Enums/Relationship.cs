using System.Collections.Generic;

namespace ForSureLife.Models.Enums
{
    public enum Relationship
    {
        //multiple potential. If only 1 beneficiary it is just considered primary. If multiple 1 - 17 then consider it 
        // mupltiple and fill out the ammednemnt 
        NoRelationship = 0,
        Primary = 1,
        Spouse = 2,
        ChildDaughter = 3,
        ChildSon = 4,
        Mother = 5,
        Father = 6,
        Brother = 7,
        Sister = 8,
        Cousin = 9,
        Aunt = 10,
        Uncle = 11,
        GrandFather = 12,
        GrandMother = 13,
        GrandParent = 14,
        GrandChild = 15,
        Niece = 16,
        Nephew = 17,
        Child = 18,
        Relative = 19,
        Other = 20,
        //Only 1 and if present fill out the policy owner in the pdf with this value
        SeparatePolicyOwnerSpouse = 21,
        SeparatePolicyOwnerLifePartner = 22,
        SeparatePolicyOwnerFiance = 23,
        SeparatePolicyOwnerChild = 24,
        SeparatePolicyOwnerOther = 25,
        Fiance = 26,
        Estate = 27,
        Trust = 28,
        LifePartner = 29
    }
    public class RelationShipExtension
    {
        public static HashSet<Relationship> FamilyRelations()
        {
            return new HashSet<Relationship>(){
                Relationship.Spouse,
                Relationship.Mother,
                Relationship.Father,
                Relationship.ChildDaughter,
                Relationship.ChildSon,
                Relationship.Brother,
                Relationship.Sister,
                Relationship.Cousin,
                Relationship.Aunt,
                Relationship.Uncle,
                Relationship.GrandFather,
                Relationship.GrandMother,
                Relationship.GrandChild,
                Relationship.Niece,
                Relationship.Nephew
            };
        }
    }
}