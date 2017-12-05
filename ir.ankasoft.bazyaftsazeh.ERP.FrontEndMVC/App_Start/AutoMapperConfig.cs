using AutoMapper;
using ir.ankasoft.bazyaftsazeh.ERP.entities;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Cities;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Communication;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Cost;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Document;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.DocumentCost;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Imperfection;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Importer;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Notification;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Organization;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Party;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Person;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.PostalAddress;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Province;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Vehicle;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehiclePlate;
using ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.VehicleTip;
using ir.ankasoft.entities;
using System.Linq;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(_ =>
            {
                /*CounterParty*/
                ConfigParty(_);

                /*Person*/
                ConfigPerson(_);

                /*Organization*/
                ConfigOrganization(_);

                /*Importer*/
                ConfigImporter(_);

                /*Communication*/
                ConfigCommunication(_);

                /*PostalAddress*/
                ConfigPostalAddress(_);

                /*Province*/
                ConfigProvince(_);

                /*City*/
                ConfigCity(_);

                /*Vehicle Tip*/
                ConfigVehicleTip(_);

                /*Cost*/
                ConfigCost(_);

                /*Imperfection*/
                ConfigImperfection(_);

                /*Document*/
                ConfigDocument(_);

                /*Document Cost*/
                ConfigDocumentCost(_);

                /*ConfigVehicle*/
                ConfigVehicle(_);

                /*ConfigVehicle*/
                ConfigVehiclePlate(_);

                //*Notification*/
                ConfigNotification(_);

                //*Shared */
                //ConfigShared(_);

                //*ContextMenu*/
                ConfigContextMenu(_);
            });

            MapperConfiguration.AssertConfigurationIsValid();
        }

        private static void ConfigParty(IMapperConfigurationExpression _)
        {
            //Display
            _.CreateMap<ViewModelPartyDisplay, Party>()
                .ForMember(p => p.PersonalTitle, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
                .ForMember(p => p.CommunicationCollection, t => t.Ignore())
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));
            _.CreateMap<Party, ViewModelPartyDisplay>()
                .ForMember(p => p.Roles, t => t.Ignore())
                .ForMember(p => p.Telephone, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Telephone)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.Mobile, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Mobile)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            //Create
            _.CreateMap<ViewModelCreateParty, Party>()
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Party, ViewModelCreateParty>();

            //Modify
            _.CreateMap<ViewModelModifyParty, Party>()
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Party, ViewModelModifyParty>();

            _.CreateMap<ViewModelPartyCommunication, Party>()
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.Description, t => t.Ignore())
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Party, ViewModelPartyCommunication>();
        }

        private static void ConfigPerson(IMapperConfigurationExpression _)
        {
            //Display
            _.CreateMap<ViewModelPersonDisplay, Person>()
                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.Party, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
                .ForMember(p => p.CommunicationCollection, t => t.Ignore())
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            _.CreateMap<Person, ViewModelPersonDisplay>()
                .ForMember(p => p.Telephone, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Telephone)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.Mobile, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Mobile)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.NationalCode, opt => opt.MapFrom(dest => dest.Party.NationalCode))
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            //Create
            _.CreateMap<ViewModelCreatePerson, Person>()
                .ForMember(p => p.PartyRefRecId, opt => opt.MapFrom(dest => dest.parentId))
                .ForMember(p => p.Party, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Person, ViewModelCreatePerson>()
                .ForMember(p => p.parentId, t => t.Ignore());

            //Modify
            _.CreateMap<ViewModelModifyPerson, Person>()
               .ForMember(p => p.PartyRefRecId, t => t.Ignore())
               .ForMember(p => p.Party, t => t.Ignore())
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Person, ViewModelModifyPerson>();

            _.CreateMap<ViewModelPersonCommunication, Person>()
               .ForMember(p => p.Name, t => t.Ignore())
               .ForMember(p => p.Family, t => t.Ignore())
               .ForMember(p => p.PartyRefRecId, t => t.Ignore())
               .ForMember(p => p.Party, t => t.Ignore())
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Person, ViewModelPersonCommunication>()
                .ForMember(p => p.PersonalTitle, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.NationalCode, t => t.Ignore());
        }

        private static void ConfigImporter(IMapperConfigurationExpression _)
        {
            //Display
            _.CreateMap<ViewModelImporterDisplay, Importer>()
                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.Party, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
                .ForMember(p => p.CommunicationCollection, t => t.Ignore())
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            _.CreateMap<Importer, ViewModelImporterDisplay>()
                .ForMember(p => p.Telephone, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Telephone)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.Mobile, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Mobile)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.NationalCode, opt => opt.MapFrom(dest => dest.Party.NationalCode))
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            //Create
            _.CreateMap<ViewModelCreateImporter, Importer>()
                .ForMember(p => p.PartyRefRecId, opt => opt.MapFrom(dest => dest.parentId))
                .ForMember(p => p.Party, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Importer, ViewModelCreateImporter>()
                .ForMember(p => p.parentId, t => t.Ignore());

            //Modify
            _.CreateMap<ViewModelModifyImporter, Importer>()
               .ForMember(p => p.PartyRefRecId, t => t.Ignore())
               .ForMember(p => p.Party, t => t.Ignore())
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Importer, ViewModelModifyImporter>();

            _.CreateMap<ViewModelImporterCommunication, Importer>()
               .ForMember(p => p.Name, t => t.Ignore())
               .ForMember(p => p.Family, t => t.Ignore())
               .ForMember(p => p.ImporterNumber, t => t.Ignore())
               .ForMember(p => p.PartyRefRecId, t => t.Ignore())
               .ForMember(p => p.Party, t => t.Ignore())
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Importer, ViewModelImporterCommunication>()
                .ForMember(p => p.PersonalTitle, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.NationalCode, t => t.Ignore());
        }

        private static void ConfigOrganization(IMapperConfigurationExpression _)
        {
            //Display
            _.CreateMap<ViewModelOrganizationDisplay, Organization>()
                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.Party, t => t.Ignore())

                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
                .ForMember(p => p.CommunicationCollection, t => t.Ignore())
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            _.CreateMap<Organization, ViewModelOrganizationDisplay>()
                .ForMember(p => p.Telephone, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Telephone)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.Mobile, opt =>
                        opt.MapFrom(desc =>
                                desc.CommunicationCollection.Where(x => x.IsPrimary == true &&
                                                                   x.CommunicationType == ankasoft.entities.Enums.CommunicationType.Mobile)
                                                            .FirstOrDefault().Value))
                .ForMember(p => p.NationalCode, opt => opt.MapFrom(dest => dest.Party.NationalCode))
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            //Create
            _.CreateMap<ViewModelCreateOrganization, Organization>()
                .ForMember(p => p.PartyRefRecId, opt => opt.MapFrom(dest => dest.parentId))
                .ForMember(p => p.Party, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Organization, ViewModelCreateOrganization>()
                .ForMember(p => p.parentId, t => t.Ignore());

            //Modify
            _.CreateMap<ViewModelModifyOrganization, Organization>()
               .ForMember(p => p.PartyRefRecId, t => t.Ignore())
               .ForMember(p => p.Party, t => t.Ignore())
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Organization, ViewModelModifyOrganization>();

            _.CreateMap<ViewModelOrganizationCommunication, Organization>()
               .ForMember(p => p.RegistrationNumber, t => t.Ignore())
               .ForMember(p => p.RegistrationPlace, t => t.Ignore())
               .ForMember(p => p.CommercialNumber, t => t.Ignore())
               .ForMember(p => p.PartyRefRecId, t => t.Ignore())
               .ForMember(p => p.Party, t => t.Ignore())
               .ForMember(p => p.CommunicationCollection, t => t.Ignore())
               .ForMember(p => p.PostalAddressCollection, t => t.Ignore())
               .ForMember(p => p.createdDateTime, t => t.Ignore())
               .ForMember(p => p.modifiedDateTime, t => t.Ignore())
               .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
               .ForMember(p => p.creatorUser, t => t.Ignore())
               .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
               .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Organization, ViewModelOrganizationCommunication>()
                .ForMember(p => p.PersonalTitle, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.NationalCode, t => t.Ignore());
        }

        private static void ConfigCommunication(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelCommunication, Communication>()
                .ForMember(p => p.CommunicationType, opt => opt.MapFrom(dest => dest.Type))
                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.PersonRefRecId, t => t.Ignore())
                .ForMember(p => p.ImporterRefRecId, t => t.Ignore())
                .ForMember(p => p.OrganizationRefRecId, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<Communication, ViewModelCommunication>()
                .ForMember(p => p.ParentId, opt => opt.MapFrom(dest => dest.PartyRefRecId))
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.CommunicationType));

            _.CreateMap<ViewModelCreateModifyCommunication, Communication>()
                .ForMember(p => p.CommunicationType, opt => opt.MapFrom(dest => dest.Type))
                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.PersonRefRecId, t => t.Ignore())
                .ForMember(p => p.ImporterRefRecId, t => t.Ignore())
                .ForMember(p => p.OrganizationRefRecId, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<Communication, ViewModelCreateModifyCommunication>()
                .ForMember(p => p.ObjectiveType, t => t.Ignore())
                .ForMember(p => p.ParentId, t => t.Ignore())
                .ForMember(p => p.PersonalTitle, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.NationalCode, t => t.Ignore())
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.CommunicationType));
        }

        private static void ConfigPostalAddress(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelPostalAddress, PostalAddress>()
                .ForMember(p => p.Province, t => t.Ignore())
                .ForMember(p => p.City, t => t.Ignore())

                .ForMember(p => p.IsPrimary, opt => opt.MapFrom(dest => dest.Postal_IsPrimary))
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.Postal_Type))
                .ForMember(p => p.Value, opt => opt.MapFrom(dest => dest.Postal_Value))
                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.Postal_recId))

                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.PersonRefRecId, t => t.Ignore())
                .ForMember(p => p.ImporterRefRecId, t => t.Ignore())
                .ForMember(p => p.OrganizationRefRecId, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<PostalAddress, ViewModelPostalAddress>()
                .ForMember(p => p.Postal_ParentId, t => t.Ignore())
                .ForMember(p => p.Postal_recId, opt => opt.MapFrom(dest => dest.recId))
                .ForMember(p => p.Postal_IsPrimary, opt => opt.MapFrom(dest => dest.IsPrimary))
                .ForMember(p => p.Postal_Type, opt => opt.MapFrom(dest => dest.Type))
                .ForMember(p => p.Postal_Value, opt => opt.MapFrom(dest => dest.Value))
                .ForMember(p => p.ProvinceCity, opt => opt.MapFrom(dest => $"{dest.CityRefRecId},{dest.ProvinceRefRecId}"))
                .ForMember(p => p.Province, opt => opt.MapFrom(dest => dest.Province.Title))
                .ForMember(p => p.City, opt => opt.MapFrom(dest => dest.City.Title))
                .ForMember(p => p.ProvinceCityList, t => t.Ignore());

            _.CreateMap<ViewModelCreateModifyPostalAddress, PostalAddress>()
                .ForMember(p => p.Province, t => t.Ignore())
                .ForMember(p => p.City, t => t.Ignore())

                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.Type))
                .ForMember(p => p.PartyRefRecId, t => t.Ignore())
                .ForMember(p => p.PersonRefRecId, t => t.Ignore())
                .ForMember(p => p.ImporterRefRecId, t => t.Ignore())
                .ForMember(p => p.OrganizationRefRecId, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<PostalAddress, ViewModelCreateModifyPostalAddress>()
                .ForMember(p => p.Province, opt => opt.MapFrom(dest => dest.Province.Title))
                .ForMember(p => p.City, opt => opt.MapFrom(dest => dest.City.Title))
                .ForMember(p => p.ParentId, t => t.Ignore())
                .ForMember(p => p.ObjectiveType, t => t.Ignore())
                .ForMember(p => p.PersonalTitle, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.NationalCode, t => t.Ignore())
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.Type))
                .ForMember(p => p.ProvinceCity, t => t.Ignore())
                .ForMember(p => p.ProvinceCityList, t => t.Ignore());
        }

        private static void ConfigProvince(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelDisplayProvince, Province>()
                .ForMember(p => p.Cities, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Province, ViewModelDisplayProvince>();
        }

        private static void ConfigCity(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelDisplayCity, City>()
                .ForMember(p => p.ProvinceRefRecID, t => t.Ignore())
                .ForMember(p => p.Province, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<City, ViewModelDisplayCity>()
                .ForMember(p => p.Province, opt => opt.MapFrom(dest => dest.Province.Title));
        }

        private static void ConfigVehicleTip(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelVehicleTipDisplay, VehicleTip>()
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())

                .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.recId));

            _.CreateMap<VehicleTip, ViewModelVehicleTipDisplay>();

            //Create
            _.CreateMap<ViewModelCreateAndEditVehicleTip, VehicleTip>()
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<VehicleTip, ViewModelCreateAndEditVehicleTip>();
        }

        private static void ConfigCost(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelCostDisplay, Cost>()
                .ForMember(p => p.PreDefineTitleRefRecId, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore());

            _.CreateMap<Cost, ViewModelCostDisplay>()
                .ForMember(p => p.Title, opt => opt.MapFrom(dest => dest.Title.Title));

            //Create
            _.CreateMap<ViewModelCreateAndModifyCost, Cost>()
                .ForMember(p => p.PreDefineTitleRefRecId, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Cost, ViewModelCreateAndModifyCost>()
                .ForMember(p => p.Title, opt => opt.MapFrom(dest => dest.Title.Title));
        }

        private static void ConfigDocument(IMapperConfigurationExpression _)
        {
            /*Display*/
            //_.CreateMap<ViewModelDocumentDisplay, Document>()
            //    .ForMember(p => p.LastOwnerRefRecId, t => t.Ignore())
            //    .ForMember(p => p.PlateOwnerRefRecId, t => t.Ignore())
            //    .ForMember(p => p.InvestorRefRecId, t => t.Ignore())
            //    .ForMember(p => p.Investor, t => t.Ignore())
            //    .ForMember(p => p.VehicleRefRecId, t => t.Ignore())
            //    .ForMember(p => p.PaymentType, t => t.Ignore())
            //    .ForMember(p => p.PaymentDate, t => t.Ignore())
            //    .ForMember(p => p.ContractorRefRecId, t => t.Ignore())
            //    .ForMember(p => p.Contractor, t => t.Ignore())
            //    .ForMember(p => p.Costs, t => t.Ignore())
            //    .ForMember(p => p.Imperfections, t => t.Ignore())
            //    .ForMember(p => p.ReplacementRefRecId, t => t.Ignore())
            //    .ForMember(p => p.ReplacementPlan, t => t.Ignore())
            //    .ForMember(p => p.GovernmentPlanRefRecId, t => t.Ignore())
            //    .ForMember(p => p.GovernmentPlan, t => t.Ignore())
            //    .ForMember(p => p.Payments, t => t.Ignore())
            //    .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
            //    .ForMember(p => p.creatorUser, t => t.Ignore())
            //    .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
            //    .ForMember(p => p.modifierUser, t => t.Ignore())
            //    .ForMember(p => p.createdDateTime, t => t.Ignore())
            //    .ForMember(p => p.modifiedDateTime, t => t.Ignore());

            _.CreateMap<Document, ViewModelDisplayDocument>()
            .ForMember(p => p.LastOwner, opt => opt.MapFrom(dest => dest.LastOwner.Title))
            .ForMember(p => p.PlateOwner, opt => opt.MapFrom(dest => dest.PlateOwner.Title))
            .ForMember(p => p.Vehicle, opt => opt.MapFrom(dest => dest.Vehicle.ToString()))
            .ForMember(p => p.PlateNumber, opt => opt.MapFrom(dest => dest.Vehicle.Plate.ToString()))
            .ForMember(p => p.TotalCostValue, opt => opt.MapFrom(dest => dest.Costs.Sum(x => x.Value)));

            /*Create*/
            _.CreateMap<ViewModelCreateDocument, Document>()
                .ForMember(p => p.LastOwnerRefRecId, opt => opt.MapFrom(dest => dest.LastOwnerRecId))
                .ForMember(p => p.LastOwner, t => t.Ignore())
                .ForMember(p => p.PlateOwnerRefRecId, opt => opt.MapFrom(dest => dest.PlateOwnerRecId))
                .ForMember(p => p.PlateOwner, t => t.Ignore())
                .ForMember(p => p.InvestorRefRecId, opt => opt.MapFrom(dest => dest.InvestorRecId))
                .ForMember(p => p.Investor, t => t.Ignore())
                .ForMember(p => p.VehicleRefRecId, t => t.Ignore())

                .ForMember(p => p.PaymentDate, t => t.Ignore())
                .ForMember(p => p.ContractorRefRecId, opt => opt.MapFrom(dest => dest.ContractorRecId))
                .ForMember(p => p.Contractor, t => t.Ignore())
                .ForMember(p => p.Costs, t => t.Ignore())
                .ForMember(p => p.Imperfections, t => t.Ignore())
                .ForMember(p => p.ReplacementRefRecId, t => t.Ignore())
                .ForMember(p => p.ReplacementPlan, t => t.Ignore())
                .ForMember(p => p.GovernmentPlanRefRecId, t => t.Ignore())
                .ForMember(p => p.GovernmentPlan, t => t.Ignore())
                .ForMember(p => p.Payments, t => t.Ignore())

                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<ViewModelModifyDocument, Document>()
                .ForMember(p => p.LastOwnerRefRecId, opt => opt.MapFrom(dest => dest.LastOwnerRecId))
                .ForMember(p => p.LastOwner, t => t.Ignore())
                .ForMember(p => p.PlateOwnerRefRecId, opt => opt.MapFrom(dest => dest.PlateOwnerRecId))
                .ForMember(p => p.PlateOwner, t => t.Ignore())
                .ForMember(p => p.InvestorRefRecId, opt => opt.MapFrom(dest => dest.InvestorRecId))
                .ForMember(p => p.Investor, t => t.Ignore())
                .ForMember(p => p.VehicleRefRecId, t => t.Ignore())
                .ForMember(p => p.PaymentDate, t => t.Ignore())
                .ForMember(p => p.ContractorRefRecId, opt => opt.MapFrom(dest => dest.ContractorRecId))
                .ForMember(p => p.Contractor, t => t.Ignore())
                .ForMember(p => p.Costs, t => t.Ignore())
                .ForMember(p => p.Imperfections, t => t.Ignore())
                .ForMember(p => p.PlanType, t => t.Ignore())
                .ForMember(p => p.ReplacementRefRecId, t => t.Ignore())
                .ForMember(p => p.ReplacementPlan, t => t.Ignore())
                .ForMember(p => p.GovernmentPlanRefRecId, t => t.Ignore())
                .ForMember(p => p.GovernmentPlan, t => t.Ignore())
                .ForMember(p => p.Payments, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Document, ViewModelModifyDocument>()
                .ForMember(p => p.IsAnyPaymentPaid, t => t.Ignore())
                .ForMember(p => p.LastOwner, t => t.Ignore())
                .ForMember(p => p.PlateOwner, t => t.Ignore())
                .ForMember(p => p.Investor, t => t.Ignore())
                .ForMember(p => p.Contractor, t => t.Ignore())
                .ForMember(p => p.Vehicle, t => t.Ignore());
        }

        private static void ConfigDocumentCost(IMapperConfigurationExpression _)
        {
            /*Create*/
            _.CreateMap<DocumentCost, ViewModelCreateAndModifyDocumentCost>()
            .ForMember(p => p.CostRecId, opt => opt.MapFrom(dest => dest.recId))
            .ForMember(p => p.CostTitle, opt => opt.MapFrom(dest => dest.Title))
            .ForMember(p => p.CostValue, opt => opt.MapFrom(dest => dest.Value))
            .ForMember(p => p.CostList, t => t.Ignore());

            _.CreateMap<ViewModelCreateAndModifyDocumentCost, DocumentCost>()
            .ForMember(p => p.recId, opt => opt.MapFrom(dest => dest.CostRecId))
            .ForMember(p => p.PreDefineTitleRefRecId, t => t.Ignore())
            .ForMember(p => p.Title, t => t.Ignore())//, opt => opt.MapFrom(dest => dest.CostTitle))
            .ForMember(p => p.Value, opt => opt.MapFrom(dest => dest.CostValue))
            .ForMember(p => p.DocumentRefRecId, t => t.Ignore())
            .ForMember(p => p.Document, t => t.Ignore())
            .ForMember(p => p.createdDateTime, t => t.Ignore())
            .ForMember(p => p.modifiedDateTime, t => t.Ignore())
            .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
            .ForMember(p => p.creatorUser, t => t.Ignore())
            .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
            .ForMember(p => p.modifierUser, t => t.Ignore());

            //.ForMember(p => p.LastOwnerRefRecId, opt => opt.MapFrom(dest => dest.LastOwnerRecId))
            //.ForMember(p => p.LastOwner, t => t.Ignore())
            //.ForMember(p => p.PlateOwnerRefRecId, opt => opt.MapFrom(dest => dest.PlateOwnerRecId))
            //.ForMember(p => p.PlateOwner, t => t.Ignore())
            //.ForMember(p => p.InvestorRefRecId, opt => opt.MapFrom(dest => dest.InvestorRecId))
            //.ForMember(p => p.Investor, t => t.Ignore())
            //.ForMember(p => p.VehicleRefRecId, t => t.Ignore())
            //.ForMember(p => p.Vehicle, t => t.Ignore())
            //.ForMember(p => p.PaymentDate, t => t.Ignore())
            //.ForMember(p => p.ContractorRefRecId, opt => opt.MapFrom(dest => dest.ContractorRecId))
            //.ForMember(p => p.Contractor, t => t.Ignore())
            //.ForMember(p => p.Costs, t => t.Ignore())
            //.ForMember(p => p.Imperfections, t => t.Ignore())
            //.ForMember(p => p.ReplacementRefRecId, t => t.Ignore())
            //.ForMember(p => p.ReplacementPlan, t => t.Ignore())
            //.ForMember(p => p.GovernmentPlanRefRecId, t => t.Ignore())
            //.ForMember(p => p.GovernmentPlan, t => t.Ignore())
            //.ForMember(p => p.Payments, t => t.Ignore())

            //.ForMember(p => p.createdDateTime, t => t.Ignore())
            //.ForMember(p => p.modifiedDateTime, t => t.Ignore())
            //.ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
            //.ForMember(p => p.creatorUser, t => t.Ignore())
            //.ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
            //.ForMember(p => p.modifierUser, t => t.Ignore());

            //_.CreateMap<Document, ViewModelCreateDocument>()
            //    .ForMember(p => p.CostCollection, t => t.Ignore())
            //    .ForMember(p => p.ImperfectionCollection, t => t.Ignore())
            //    .ForMember(p => p.PaymentCollection, t => t.Ignore())
            //    .ForMember(p => p.BeneficiaryImporterRecId, t => t.Ignore())
            //    .ForMember(p => p.BeneficiaryImporter, t => t.Ignore())
            //    .ForMember(p => p.ReplacementVehicleRecId, t => t.Ignore())
            //    .ForMember(p => p.ReplacementVehicle, t => t.Ignore())
            //    .ForMember(p => p.RepresentorRecId, t => t.Ignore())
            //    .ForMember(p => p.Representor, t => t.Ignore())
            //    .ForMember(p => p.OrganizationRecId, t => t.Ignore())
            //    .ForMember(p => p.Organization, t => t.Ignore())
            //    .ForMember(p => p.PermissionNumber, t => t.Ignore());
            //.ForMember(p => p.Title, opt => opt.MapFrom(dest => dest.Title.Title));
        }

        private static void ConfigVehicle(IMapperConfigurationExpression _)
        {
            /*Display*/
            //_.CreateMap<ViewModelCreateDocument, Document>()
            //    //.ForMember(p => p.PreDefineTitleRefRecId, t => t.Ignore())
            //    //.ForMember(p => p.Title, t => t.Ignore())
            //    .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
            //    .ForMember(p => p.creatorUser, t => t.Ignore())
            //    .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
            //    .ForMember(p => p.modifierUser, t => t.Ignore())
            //    .ForMember(p => p.createdDateTime, t => t.Ignore())
            //    .ForMember(p => p.modifiedDateTime, t => t.Ignore());

            //_.CreateMap<Document, ViewModelCreateDocument>();
            //.ForMember(p => p.Title, opt => opt.MapFrom(dest => dest.Title.Title));

            /*Create*/
            _.CreateMap<ViewModelCreateAndModifyVehicle, Vehicle>()
                .ForMember(p => p.VehicleTip, t => t.Ignore())
                .ForMember(p => p.VehicleTipRefRecId, t => t.Ignore())
                .ForMember(p => p.Plate, t => t.Ignore())
                .ForMember(p => p.PlateRefRecId, t => t.Ignore())//, opt => opt.MapFrom(dest => dest.PlateRecId))
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Vehicle, ViewModelCreateAndModifyVehicle>()
                .ForMember(p => p.VehicleTip, t => t.Ignore());
        }

        private static void ConfigVehiclePlate(IMapperConfigurationExpression _)
        {
            /*Display*/
            //_.CreateMap<ViewModelCreateDocument, Document>()
            //    //.ForMember(p => p.PreDefineTitleRefRecId, t => t.Ignore())
            //    //.ForMember(p => p.Title, t => t.Ignore())
            //    .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
            //    .ForMember(p => p.creatorUser, t => t.Ignore())
            //    .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
            //    .ForMember(p => p.modifierUser, t => t.Ignore())
            //    .ForMember(p => p.createdDateTime, t => t.Ignore())
            //    .ForMember(p => p.modifiedDateTime, t => t.Ignore());

            //_.CreateMap<Document, ViewModelCreateDocument>();
            //.ForMember(p => p.Title, opt => opt.MapFrom(dest => dest.Title.Title));

            /*Create*/
            _.CreateMap<ViewModelCreateAndModifyVehiclePlate, Plate>()
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Plate, ViewModelCreateAndModifyVehiclePlate>()
                ;
        }

        private static void ConfigImperfection(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelImperfectionDisplay, Imperfection>()
                .ForMember(p => p.PreDefineTitleRefRecId, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore());

            _.CreateMap<Imperfection, ViewModelImperfectionDisplay>()
                .ForMember(p => p.Title, opt => opt.MapFrom(dest => dest.Title.Title));

            //Create
            _.CreateMap<ViewModelCreateAndModifyImperfection, Imperfection>()
                .ForMember(p => p.PreDefineTitleRefRecId, t => t.Ignore())
                .ForMember(p => p.Title, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());

            _.CreateMap<Imperfection, ViewModelCreateAndModifyImperfection>()
                .ForMember(p => p.Title, opt => opt.MapFrom(dest => dest.Title.Title));
        }

        private static void ConfigNotification(IMapperConfigurationExpression _)
        {
            _.CreateMap<ViewModelDisplayNotification, Notification>()
                .ForMember(p => p.Body, t => t.Ignore())
                .ForMember(p => p.PublishDate, t => t.Ignore())
                .ForMember(p => p.PublishDateShamsi, t => t.Ignore())
                .ForMember(p => p.Type, t => t.Ignore())
                .ForMember(p => p.createdDateTime, t => t.Ignore())
                .ForMember(p => p.modifiedDateTime, t => t.Ignore())
                .ForMember(p => p.creatorUserRefRecId, t => t.Ignore())
                .ForMember(p => p.creatorUser, t => t.Ignore())
                .ForMember(p => p.modifierUserRefRecId, t => t.Ignore())
                .ForMember(p => p.modifierUser, t => t.Ignore());
            _.CreateMap<Notification, ViewModelDisplayNotification>()
                .ForMember(p => p.Type, opt => opt.MapFrom(dest => dest.Type.ToString()))
                .ForMember(p => p.Age, opt => opt.MapFrom(dest => dest.PublishDateAge));
        }

        private static void ConfigContextMenu(IMapperConfigurationExpression _)
        {
            _.CreateMap<ContextMenuItem, ViewModelContextMenu>();
        }
    }
}