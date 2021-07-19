using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ForSureLife.repo.Migrations
{
    public partial class migrationUpdateForAllStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RXFrequency",
                table: "CarrierDrug");

            migrationBuilder.InsertData(
               table: "AmState",
               columns: new[] { "AmStateId", "InsuranceCompany", "StateIdEnum" },
               values: new object[,]
               {
                    { new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156"), 0, 4 },
                    { new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735"), 0, 7 },
                    { new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0"), 0, 8 },
                    { new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9"), 0, 9 },
                    { new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477"), 0, 26 },
                    { new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954"), 0, 28 },
                    { new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8"), 0, 30 },
                    { new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7"), 0, 34 },
                    { new Guid("f47f6449-dee5-4255-93c2-37a1c805d176"), 0, 41}
               });

            migrationBuilder.InsertData(
                             table: "AmStateLookup",
                             columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                             values: new object[,]
                             {
                             { new Guid ("93F597CC-6DD4-01FD-0540-C153EBFE7C99"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                            { new Guid ("DF983097-73A4-7591-6F43-D1BA0F0E129C"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                            { new Guid ("C2DF1C16-3C72-042E-158D-C3ED63B34DCA"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                            { new Guid ("6D4B13F8-9617-32BD-10F1-CE640D0C4064"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                            { new Guid ("79C5A7B9-5648-8376-674D-A7E2D2328175"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                            { new Guid ("7E4C0CDB-6541-4F47-3D20-0094B4EF29DC"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                            { new Guid ("36707EE0-34B0-4803-83DD-139D8DB59C54"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                            { new Guid ("F07C7E2D-5043-08B0-607B-65D0A4455DCB"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                            { new Guid ("1B9550AE-5466-4C7F-44F5-101D57DE59B7"), new Guid("e494a4bd-881a-376a-711e-757e27ce3469"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

                      });

            migrationBuilder.InsertData(
                   table: "AmStateLookup",
                   columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                   values: new object[,]
                   {
                            { new Guid ("58E4DA73-420D-098D-968F-DD1594722876"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                            { new Guid ("2A72AA9F-2E6A-4A11-736B-BF15456755C5"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                            { new Guid ("B7BB7AB9-91A0-6A23-6042-9B9F019A8E81"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                            { new Guid ("433DC5FD-0D3B-0AF9-6F0C-69021EE42876"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                            { new Guid ("ED712D5C-9658-6218-1375-AD4BF1D083BC"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                            { new Guid ("FDC7D3D2-A1BF-8790-5050-2EFD24D8057A"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                            { new Guid ("617B8473-856A-28A5-23D3-E8940376225D"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                            { new Guid ("C62630D8-7D3A-1AFA-4CAC-6B41D8E6330C"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                            { new Guid ("913B9B83-8AEB-97CA-3962-437078CB29A2"), new Guid("e494a4bc-885a-376a-711e-757e27ce3769"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}


            });

            migrationBuilder.InsertData(
               table: "AmStateLookup",
               columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
               values: new object[,]
               {
                            { new Guid ("B47DC455-939D-1CD8-87E3-2728E7F865A1"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                            { new Guid ("D0AA8E92-9D4E-A19E-7F02-066BE2AE57B5"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                            { new Guid ("A3F35C36-3682-3FB1-5902-B96A7CA57F31"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                            { new Guid ("B99FABD3-50C0-137A-3186-3F071E530BCC"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                            { new Guid ("310D8D06-11E1-16AB-031C-9C07FDA22D30"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                            { new Guid ("AF74D11C-1E02-7F96-6BEA-6DACCD911489"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                            { new Guid ("2524C24F-551A-6CB7-9B41-7C4D36C06C7A"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                            { new Guid ("17A6BEED-1FBB-6E65-46C6-0CF4455F55AD"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                            { new Guid ("4B758E21-959E-2FAF-9696-AF8512DD8055"), new Guid("e494a4bc-884a-376a-711e-757e27ce3669"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}


        });

            migrationBuilder.InsertData(
                        table: "AmStateLookup",
                        columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                        values: new object[,]
                        {
                                { new Guid ("358419F0-008B-9AE8-43D2-A4D0A90A3ACF"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                                { new Guid ("8D517F82-6AD6-0A96-18EE-0CA00AB6237F"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                                { new Guid ("14A75426-2155-0D3C-2745-B889F03A6EC5"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                                { new Guid ("82D14F38-0516-0470-7FAD-1D8E4AA13991"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                                { new Guid ("5F04934A-0C74-059D-52B9-C96BFB307301"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                                { new Guid ("89AF5344-1424-854C-0ABC-70B1DDA31B26"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                                { new Guid ("5720CBD9-425F-8939-592A-811387F55DA9"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                                { new Guid ("B9F4EE61-8F6C-3413-680D-1736CAC72BDA"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                                { new Guid ("1909EB95-01A0-8CE1-11F5-A7AA9A4D159B"), new Guid("e494a4bc-882a-376a-711e-757e27ce3469"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}


                 });
            migrationBuilder.InsertData(
               table: "AmStateLookup",
               columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
               values: new object[,]
               {
                            { new Guid ("9FE82477-1E5A-1F60-028A-6173831E5AC7"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                            { new Guid ("37FC976E-785D-1D15-9EE2-C14D02E4975C"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                            { new Guid ("BB79FDB6-4FEF-0991-9FBE-85320DCD3A01"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                            { new Guid ("1CF5E258-1E1E-0516-6254-35719E42791C"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                            { new Guid ("ADBE6333-0292-60E9-4F53-E041B7DC73C3"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                            { new Guid ("BE99847A-445C-9059-77B3-EDC342D48293"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                            { new Guid ("DDCB3AFB-3656-42FE-92A8-D4F621095A78"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                            { new Guid ("D754539B-36D3-2655-44ED-089C7A8CA3D5"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                            { new Guid ("33876DE9-51AD-7086-3F3B-00D166372E99"), new Guid("e494a4bc-801a-376a-711e-757e27ce3369"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

        });
            migrationBuilder.InsertData(
               table: "AmStateLookup",
               columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
               values: new object[,]
               {
                            { new Guid ("2C8979E0-08E2-1F80-11B3-91530CA6602D"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                            { new Guid ("53B0A88C-62C0-0E01-6CCC-054FDD241E97"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                            { new Guid ("41A2172E-1723-27D6-2F0E-900C90B39FFE"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                            { new Guid ("544E5E3B-0BC4-1E34-0D58-BB31069B7818"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                            { new Guid ("6102F897-407B-5F88-47DC-F485853A1CE9"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                            { new Guid ("0760BAF1-4581-1C87-6564-01EDF080066D"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                            { new Guid ("4C9CC6EE-9794-97C6-9F20-010238C48216"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                            { new Guid ("4AF13FF0-71B6-13BB-14EC-1C52BFFD88ED"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                            { new Guid ("F1AAE3E5-9716-30F7-3C77-D7FEDD355758"), new Guid("e494a4bc-811a-376a-711e-757e27ce3269"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

        });
            migrationBuilder.InsertData(
                   table: "AmStateLookup",
                   columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
                   values: new object[,]
                   {
                            { new Guid ("B921039C-275C-A448-38F5-9066209521F9"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                            { new Guid ("D8E999F3-682C-27F4-7BE9-B72378DE4E79"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                            { new Guid ("8CBA347E-11D2-0ADC-6CB4-27E136F6A218"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                            { new Guid ("710736D0-5C94-4C47-3BD3-8ABFCD122B57"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                            { new Guid ("B61A1D6D-9AAA-66BB-78FF-173D649F94B6"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                            { new Guid ("0F5B7D49-46B9-83DE-A3E3-6AF2B282787D"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                            { new Guid ("306E3672-9DF8-9A33-2CD7-17A9ABA62619"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                            { new Guid ("3E824FA7-112C-78EC-71B4-224566E617CA"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                            { new Guid ("38F3C0F4-6F1F-0214-238F-56632B0913E7"), new Guid("e494a4bc-883a-376a-711e-757e27ce3569"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

            });
            migrationBuilder.InsertData(
               table: "AmStateLookup",
               columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
               values: new object[,]
               {
                             { new Guid ("E04E3F7E-7A80-3836-4DAA-1860F9420577"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                            { new Guid ("04CA5C90-0D17-A42F-411B-927C67B91D92"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                            { new Guid ("26CE33CA-53BE-83B5-5A24-BE4443CA2E91"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                            { new Guid ("4AD808AF-85B6-1734-51DC-ACC622C49A36"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                            { new Guid ("FC883F62-52A0-3771-64C0-3F6AB9BA612F"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                            { new Guid ("86AE9E6A-6C6E-89DD-0B8C-A8608596122F"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                            { new Guid ("A932B1B5-8351-A31D-9EDC-9BDD4F59812F"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                            { new Guid ("C00CAA58-7A5A-20CC-6F4E-CFF760DE2499"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                            { new Guid ("C7640A0C-5A55-9812-1FC6-F68B1F4BA3A0"), new Guid("e494a4bc-831a-376a-711e-757e27ce9369"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

        });
            migrationBuilder.InsertData(
               table: "AmStateLookup",
               columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
               values: new object[,]
               {
                            { new Guid ("CE5851ED-A57B-091A-87A9-7E8F11EB08AA"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                            { new Guid ("9ABCC147-043C-2310-1A00-AEE26A1444FA"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                            { new Guid ("A980CDEF-8D82-0933-859F-26C0157B12FB"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                            { new Guid ("D859B08D-80EE-A100-6AEC-34B63A948A4C"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                            { new Guid ("554FD26C-5961-680D-4BF6-8ECB012C42BE"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                            { new Guid ("E24CFCD5-4A66-2863-2588-D759A1194377"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                            { new Guid ("8B156547-541A-4E42-2BEA-A9219067965E"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                            { new Guid ("E64747E0-7405-949F-0430-6B6D1B9B97B6"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                            { new Guid ("AF48B836-5697-1830-A43C-AD8AF126138B"), new Guid("e494a4bc-851a-376a-711e-757e27ce8369"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

        });
            migrationBuilder.InsertData(
               table: "AmStateLookup",
               columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
               values: new object[,]
               {
                            { new Guid ("7BFC80F2-32FF-6418-9D11-106D1C6F500B"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
            { new Guid ("A1C99B53-523C-19AD-5ED8-0A0F82E26D48"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
            { new Guid ("7F423CD2-7920-23BA-2EB0-BB25A5B406B2"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
            { new Guid ("A1ADA4FA-8672-85C3-A319-6C59651A94AF"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
            { new Guid ("2756E28F-500D-27D5-739B-99E63ECB9ED3"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
            { new Guid ("D41BC183-5D39-5FBC-8F92-94C105E34954"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
            { new Guid ("CBA266DE-8529-5504-8D83-EC2794639CB1"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
            { new Guid ("D14FB465-946C-2D36-941A-E288CAD27FD9"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
            { new Guid ("3CB6CD7C-A547-6D06-3E82-F0BCEC6D5F2D"), new Guid("e494a4bc-891a-376a-711e-757e27ce7369"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

        });




            migrationBuilder.InsertData(
           table: "AmStateLookup",
           columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
           values: new object[,]
           {
                                    { new Guid ("B13DB817-4B9C-747A-6E29-E2BCC5AE86D7"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                                    { new Guid ("F94DE752-7F24-44EA-10C1-27FF4E3B4A92"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                                    { new Guid ("1082AA25-8951-A4C5-98F6-5A20B27AA2D5"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                                    { new Guid ("6AEF5894-60EC-9A86-A1EC-3ED3FA0E5E55"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                                    { new Guid ("6800772C-24B4-84B9-4FAC-9DC323C90F85"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                                    { new Guid ("A67BC3B7-7445-5202-14D0-8EBB5C525FAD"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                                    { new Guid ("ED38FFAD-0037-2F2A-A61D-6FC48F8A0DF8"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                                    { new Guid ("C8FC5C1B-4E87-6436-1159-1813C0192338"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                                    { new Guid ("88766C5A-67DD-9E94-9479-6DC1ABC23F21"), new Guid("e494a4ba-881a-376a-711e-757e27ce6369"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

            });


            migrationBuilder.InsertData(
               table: "AmStateLookup",
               columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
               values: new object[,]
               {
                                    { new Guid ("060ACF17-0750-7B15-03CA-6D79FD84500A"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
                                    { new Guid ("C4DD9E47-4A21-6F75-9218-BB62F97A6F1A"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
                                    { new Guid ("FEDE34FC-927D-2E04-235E-922BFC28379A"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
                                    { new Guid ("6D92A612-31BF-991F-6997-26A41AA02CCD"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
                                    { new Guid ("3254665C-9C3D-789E-1F41-24F8A7F90324"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
                                    { new Guid ("65332B9B-A46E-2502-93AF-61DC830C2335"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
                                    { new Guid ("C3CBFAEC-0C78-55EB-38D1-A793C0C8182A"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
                                    { new Guid ("6B43DAAE-46D5-28A0-4782-3930D72E0123"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
                                    { new Guid ("C0971FAC-2EAA-385D-3C3E-F0BF3F566B5B"), new Guid("e494a4be-881a-376a-711e-757e27ce5369"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

                });
            migrationBuilder.InsertData(
          table: "AmStateLookup",
          columns: new[] { "AmStateLookupId", "AmAmApplicationQuestionsId", "AmStateId" },
          values: new object[,]
          {
                                { new Guid ("AF491709-947C-53A0-87F1-9AD647521E58"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("47c393f6-250b-a5d0-3d88-fb95d8148ca9")},
            { new Guid ("EC5E25E0-94F9-1691-8FFC-E66A051D8E11"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("a59d28dd-e456-42ba-9103-4f9d30afd735")},
            { new Guid ("40D3C396-1C28-1353-6CD9-B9EDA0B99764"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("4ac1ed1e-b197-4a04-bd5f-0469a98e5156")},
            { new Guid ("BAAC0D61-8705-0CAF-272B-261F1EAB0A21"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("7f547089-5170-42bb-9cb5-0b32aca1b2f0")},
            { new Guid ("A334856E-4D98-6349-1090-9CB318328119"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("a480160a-2105-47cb-8c6d-f4c7088cf477")},
            { new Guid ("70B7F076-A1E2-6D68-4A03-33DEA7996778"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("6fd061d0-0a6e-4544-b650-969cc4caf954")},
            { new Guid ("59BF14D0-799F-1679-6AA3-1C0C2E280AFB"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("51de2f8e-dfe5-407a-aac6-7908dd8d31f8")},
            { new Guid ("9304AC22-9F00-27C5-A069-2154C1D5427A"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("04491b81-307c-4bf2-8ab0-c222c20ec2d7")},
            { new Guid ("B018092D-087E-5763-03BE-AA8EAD1C1FC1"), new Guid("e494a4bc-821a-376a-711e-757e27ce3169"), new Guid("f47f6449-dee5-4255-93c2-37a1c805d176")}

           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RXFrequency",
                table: "CarrierDrug",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
