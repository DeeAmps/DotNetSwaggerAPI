﻿namespace OracleHR.Helpers.queries
{
    public class DBQueries
    {
        public static string GET_REGIONS = "SELECT * FROM REGIONS";
        public static string GET_SINGLE_REGION = "SELECT * FROM REGIONS WHERE REGION_ID = {0}";
        public static string GET_DEPARTMENTS = "SELECT * FROM DEPARTMENTS";
        public static string GET_SINGLE_DEPARTMENT = "SELECT * FROM DEPARTMENTS WHERE DEPARTMENT_ID = {0}";
        public static string GET_LOCATIONS = "SELECT * FROM LOCATIONS";
        public static string GET_SINGLE_LOCATION = "SELECT * FROM LOCATIONS WHERE LOCATION_ID = {0}";
        public static string GET_EMPLOYEES = "SELECT * FROM EMPLOYEES";
        public static string GET_SINGLE_EMPLOYEE = "SELECT * FROM EMPLOYEES WHERE EMPLOYEE_ID = {0}";
        public static string GET_COUNTRIES = "SELECT * FROM COUNTRIES";
        public static string GET_SINGLE_COUNTRY = "SELECT * FROM COUNTRIES WHERE COUNTRY_ID = {0}";
        public static string GET_JOBS = "SELECT * FROM JOBS";
        public static string GET_SINGLE_JOB = "SELECT * FROM JOBS WHERE JOB_IB = {0}";
        public static string GET_LAST_REGION_ID = "SELECT REGION_ID FROM REGIONS WHERE REGION_ID=(SELECT MAX(REGION_ID) FROM REGIONS)";
        public static string INSERT_NEW_REGION = "INSERT INTO REGIONS(REGION_ID,REGION_NAME) VALUES({0}, {1}')";
        public static string REMOVE_REGION = "DELETE FROM REGIONS WHERE REGION_ID = {0}";
        public static string UPDATE_REGION = "UPDATE REGIONS SET REGION_NAME = {0} WHERE REGION_ID = {1}";
    }
}
