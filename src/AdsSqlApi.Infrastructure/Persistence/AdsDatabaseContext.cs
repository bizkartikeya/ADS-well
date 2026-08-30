using AdsSqlApi.Infrastructure.Persistence.AdsModels;
using Microsoft.EntityFrameworkCore;

namespace AdsSqlApi.Infrastructure.Persistence
{
    public class AdsDatabaseContext : DbContext
    {
        public AdsDatabaseContext(DbContextOptions<AdsDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Field> FIELD { get; set; }
        public DbSet<FiredRule> FIRED_RULE { get; set; }
        public DbSet<FiredRuleResult> FIRED_RULE_RESULT { get; set; }
        public DbSet<FiredRuleResultLookup> FIRED_RULE_RESULT_LOOKUP { get; set; }
        public DbSet<IntervalWorkflow> INTERVAL_WORKFLOW { get; set; }
        public DbSet<IntervalWorkflowNumericResult> INTERVAL_WORKFLOW_NUMERIC_RESULT { get; set; }
        public DbSet<IntervalWorkflowStringResult> INTERVAL_WORKFLOW_STRING_RESULT { get; set; }
        public DbSet<OperatorAction> OPERATOR_ACTION { get; set; }
        public DbSet<FieldFacility> FIELD_FACILITY { get; set; }
        public DbSet<FieldFacilityProperty> FIELD_FACILITY_PROPERTY { get; set; }
        public DbSet<FieldFacilityPropertyLookup> FIELD_FACILITY_PROPERTY_LOOKUP { get; set; }
        public DbSet<WellTest> WELL_TEST { get; set; }
        public DbSet<WellTestNumericResult> WELL_TEST_NUMERIC_RESULT { get; set; }
        public DbSet<WellTestStringResult> WELL_TEST_STRING_RESULT { get; set; }
        public DbSet<WellTestIntervalMapping> WELL_TEST_INTERVAL_MAPPING { get; set; }
        public DbSet<Well> WELL { get; set; }
        public DbSet<WellProperty> WELL_PROPERTY { get; set; }
        public DbSet<WellPropertyLookup> WELL_PROPERTY_LOOKUP { get; set; }
        public DbSet<WorkflowResultLookup> WORKFLOW_RESULT_LOOKUP { get; set; }
        public DbSet<OperatorActionWorkflowMapping> OPERATOR_ACTION_WORKFLOW_MAPPING { get; set; }
        public DbSet<DatabaseLog> DATABASE_LOG { get; set; }
        public DbSet<FeedbackLookup> FEEDBACK_LOOKUP { get; set; }
        public DbSet<IntervalWorkflowView> INTERVAL_WORKFLOW_VIEW { get; set; }
        public DbSet<PadInfo> PAD_INFO { get; set; }
        public DbSet<WellInfo> WELL_INFO { get; set; }
        public DbSet<WellTestView> WELL_TEST_VIEW { get; set; }
        public DbSet<XspocExceptionHistory> XSPOC_EXCEPTION_HISTORY { get; set; }
        public DbSet<IntervalWorkflowAutoPODSRecommendationResult> AUTOPODS_RECOMMENDATION_RESULT { get; set; }
        public DbSet<IntervalWorkflowAutoPODSUpliftPredictResult> AUTOPODS_UPLIFT_PREDICT_RESULT { get; set; }
        public DbSet<IntervalWorkflowPumpcardPredictResult> PUMPCARD_PREDICTION_RESULT { get; set; }
        public DbSet<IntervalWorkflowConventionalRateEstimationResult> CONVENTIONAL_RATE_ESTIMATION_RESULT { get; set; }
        public DbSet<AllWorkflowDQCResult> DATA_QUALITY_CHECK { get; set; }
        public DbSet<AFMSpeedControlResult> AFM_SPEED_CONTROL { get; set; }
        public DbSet<TagRepositoryExperion> TAG_REPOSITORY_EXPERION { get; set; }
        public DbSet<TagRepositoryPHD> TAG_REPOSITORY_PHD { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure all AdsModels are registered with explicit table mappings so
            // that migrations and database creation include every table/view declared
            // in the AdsModels folder.
            modelBuilder.Entity<Field>().ToTable("FIELD");
            modelBuilder.Entity<FieldFacility>().ToTable("FIELD_FACILITY");
            modelBuilder.Entity<FieldFacilityProperty>().ToTable("FIELD_FACILITY_PROPERTY");
            modelBuilder.Entity<FieldFacilityPropertyLookup>().ToTable("V_FIELD_FACILITY_PROPERTY");
            modelBuilder.Entity<FiredRule>().ToTable("FIRED_RULE");
            modelBuilder.Entity<FiredRuleResult>().ToTable("FIRED_RULE_RESULT");
            modelBuilder.Entity<FiredRuleResultLookup>().ToTable("V_FIRED_RULE_RESULT");
            modelBuilder.Entity<IntervalWorkflow>().ToTable("INTERVAL_WORKFLOW");
            modelBuilder.Entity<IntervalWorkflowNumericResult>().ToTable("INTERVAL_WORKFLOW_NUMERIC_RESULT");
            modelBuilder.Entity<IntervalWorkflowStringResult>().ToTable("INTERVAL_WORKFLOW_STRING_RESULT");
            modelBuilder.Entity<IntervalWorkflowView>().ToTable("IntervalWorkflowView");
            modelBuilder.Entity<IntervalWorkflowAutoPODSRecommendationResult>().ToTable("AUTOPODS_RECOMMENDATION_RESULT");
            modelBuilder.Entity<IntervalWorkflowAutoPODSUpliftPredictResult>().ToTable("AUTOPODS_UPLIFT_PREDICT_RESULT");
            modelBuilder.Entity<IntervalWorkflowPumpcardPredictResult>().ToTable("PUMPCARD_PREDICTION_RESULT");
            modelBuilder.Entity<IntervalWorkflowConventionalRateEstimationResult>().ToTable("CONVENTIONAL_RATE_ESTIMATION_RESULT");
            modelBuilder.Entity<OperatorAction>().ToTable("OPERATOR_ACTION");
            modelBuilder.Entity<OperatorActionWorkflowMapping>().ToTable("OPERATOR_ACTION_WORKFLOW_MAPPING");
            modelBuilder.Entity<PadInfo>().ToTable("PadInfo");
            modelBuilder.Entity<TagRepositoryExperion>().ToTable("TAG_REPOSITORY_EXPERION");
            modelBuilder.Entity<TagRepositoryPHD>().ToTable("TAG_REPOSITORY_PHD");
            modelBuilder.Entity<Well>().ToTable("WELL");
            modelBuilder.Entity<WellInfo>().ToTable("WellInfo");
            modelBuilder.Entity<WellProperty>().ToTable("WELL_PROPERTY");
            modelBuilder.Entity<WellPropertyLookup>().ToTable("V_WELL_PROPERTY");
            modelBuilder.Entity<WellTest>().ToTable("WELL_TEST");
            modelBuilder.Entity<WellTestIntervalMapping>().ToTable("WELL_TEST_INTERVAL_MAPPING");
            modelBuilder.Entity<WellTestNumericResult>().ToTable("WELL_TEST_NUMERIC_RESULT");
            modelBuilder.Entity<WellTestStringResult>().ToTable("WELL_TEST_STRING_RESULT");
            modelBuilder.Entity<WellTestView>().ToTable("WellTestView");
            modelBuilder.Entity<WorkflowResultLookup>().ToTable("V_WORKFLOW_RESULT");
            modelBuilder.Entity<DatabaseLog>().ToTable("ADS_LOG");
            modelBuilder.Entity<FeedbackLookup>().ToTable("V_FEEDBACK");
            modelBuilder.Entity<XspocExceptionHistory>().ToTable("XSPOC_EXCEPTION_HISTORY");
            modelBuilder.Entity<AllWorkflowDQCResult>().ToTable("DATA_QUALITY_CHECK");
            modelBuilder.Entity<AFMSpeedControlResult>().ToTable("AFM_SPEED_CONTROL");
            modelBuilder.Entity<TagRepositoryExperion>().ToTable("TAG_REPOSITORY_EXPERION");
            modelBuilder.Entity<TagRepositoryPHD>().ToTable("TAG_REPOSITORY_PHD");

            modelBuilder.Entity<Field>()
                .Property(i => i.FieldId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FieldFacility>()
               .Property(i => i.FieldFacilityId)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Well>()
                .Property(i => i.WellId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TagRepositoryExperion>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryExperion>()
                .Property(e => e.TagEntityType)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryExperion>()
                .Property(e => e.TagEntityName)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryExperion>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryExperion>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.TagEntityType)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.TagEntityName)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag1)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag2)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag3)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag4)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag5)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag6)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag7)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag8)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Tag9)
                .IsUnicode(false);

            modelBuilder.Entity<TagRepositoryPHD>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<IntervalWorkflowView>()
                .Property(e => e.WellTestType)
                .IsUnicode(false);

            modelBuilder.Entity<WellInfo>()
                .Property(e => e.WellTestType)
                .IsUnicode(false);

            modelBuilder.Entity<WellTestView>()
                .Property(e => e.WellTestType)
                .IsUnicode(false);

            modelBuilder.Entity<WellInfo>()
                .HasKey(e => new { e.WellName, e.PadId, e.WellId, e.WellTestType });

            modelBuilder.Entity<WellTestIntervalMapping>()
                .HasKey(e => new { e.WellTestId, e.IntervalWorkflowId });

            modelBuilder.Entity<IntervalWorkflowView>()
                .HasKey(e => new { e.WellName, e.PadId, e.WellId, e.WellTestType, e.IntervalWorkflowId, e.WorkflowType });

            modelBuilder.Entity<WellTestView>()
                .HasKey(e => new { e.WellName, e.PadId, e.WellId, e.WellTestType, e.WellTestId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
