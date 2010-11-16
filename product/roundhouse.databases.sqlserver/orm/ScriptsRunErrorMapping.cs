﻿namespace roundhouse.databases.sqlserver.orm
{
    using System;
    using FluentNHibernate.Mapping;
    using infrastructure;
    using model;

    [CLSCompliant(false)]
    public class ScriptsRunErrorMapping : ClassMap<ScriptsRunError>
    {
        public ScriptsRunErrorMapping()
        {
            HibernateMapping.Schema(ApplicationParameters.CurrentMappings.roundhouse_schema_name);
            Table(ApplicationParameters.CurrentMappings.scripts_run_errors_table_name);
            Not.LazyLoad();
            HibernateMapping.DefaultAccess.Property();
            HibernateMapping.DefaultCascade.SaveUpdate();

            Id(x => x.id).Column("id").GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.repository_path);
            Map(x => x.version).Length(50);
            Map(x => x.script_name);
            Map(x => x.text_of_script).CustomSqlType("ntext");
            Map(x => x.erroneous_part_of_script).CustomSqlType("ntext");
            Map(x => x.error_message).CustomSqlType("ntext");

            //audit
            Map(x => x.entry_date);
            Map(x => x.modified_date);
            Map(x => x.entered_by).Length(50);
        }
    }
}