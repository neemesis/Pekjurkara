using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Pekjurkara {
    class SQLPort {
        static string MyConString = "SERVER=localhost;" + "DATABASE=pekjurkara;" +
                "UID=root;" + "PASSWORD=to63vski;";
        

        public SQLPort() {
            
        }

        public static void insertIntoCustomers(Customer c) {

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "insert into berach (ime) value (\"" + c.ime + "\")";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void updateCustomer(Customer c) {

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "update berach set ime = \"" + c.ime + "\" where id = \"" + c.id + "\"";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static List<Customer> getAllCustomers() {
            List<Customer> list = new List<Customer>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from berach";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                int id;
                int.TryParse(Reader.GetValue(0).ToString(), out id);
                Customer c = new Customer(id, Reader.GetValue(1).ToString());
                list.Add(c);
            }
            connection.Close();
            return list;
        }

        public static int getIDForCustomer(string name) {
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select id from berach where ime = \"" + name + "\"";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                int id = -1;
                int.TryParse(Reader.GetValue(0).ToString(), out id);
                connection.Close();
                return  id;
            }
            connection.Close();
            return -1;
        }

        public static Customer getCustomerFromID(int id) {
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select ime from berach where id = \"" + id + "\"";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                string ime = Reader.GetValue(0).ToString();
                connection.Close();
                return new Customer(id, ime);
            }
            connection.Close();
            return null;
        }

        public static string getNameForCustomer(int id) {
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select ime from berach where id = \"" + id + "\"";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                string ime = Reader.GetValue(0).ToString();
                connection.Close();
                return ime;
            }
            connection.Close();
            return "";
        }

        private static DateTime getDateTimeFromTime(String time, int y, int m, int d) {
            string[] words = time.Split(':');
            int hh;
            int mm;
            int ss;
            int.TryParse(words[0], out hh);
            int.TryParse(words[1], out mm);
            int.TryParse(words[2], out ss);
            return new DateTime(y, m, d, hh, mm, ss);
        }

        public static List<CustomerDay> getCustomerDayForOneMonth(DateTime dt) {
            List<CustomerDay> list = new List<CustomerDay>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from berach_den where (den_datum between \"" +
                dt.Year + "-" + dt.Month + "-" + 1 + "\" and \"" + dt.Year + "-" + (dt.Month + 1) + "-" + 1 + "\")";

            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                int berach = Reader.GetInt32(0);
                DateTime den_datum = Reader.GetDateTime(1);
                int den_promena_cena = Reader.GetInt32(2);
                DateTime vreme = getDateTimeFromTime(Reader.GetString(3), den_datum.Year, den_datum.Month, den_datum.Day);
                double kg_1_klasa = Reader.GetDouble(4);
                double kg_2_klasa = Reader.GetDouble(5);
                double kg_3_klasa = Reader.GetDouble(6);
                double kg_lisichari = Reader.GetDouble(7);
                double kg_ovchoshapche = Reader.GetDouble(8);
                double kg_rujnica = Reader.GetDouble(9);
                int kolku_plateno = Reader.GetInt32(10);
                int dolzhi = Reader.GetInt32(11);
                int dolzhime = Reader.GetInt32(12);

                CustomerDay cd = new CustomerDay(berach, den_datum, den_promena_cena, vreme, kg_1_klasa,
                    kg_2_klasa, kg_3_klasa, kg_lisichari, kg_ovchoshapche, kg_rujnica, kolku_plateno, dolzhi, dolzhime);

                list.Add(cd);
            }
            connection.Close();

            return list;
        }

        public static List<CustomerDay> getCustomerDayFromDateAndPriceChange(DateTime datum, int price_change) {
            List<CustomerDay> list = new List<CustomerDay>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from berach_den where den_datum = \"" +
                datum.Year + "-" + datum.Month + "-" + datum.Day + "\" and den_promena_cena = \"" + price_change + "\"";

            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                int berach = Reader.GetInt32(0);
                int den_promena_cena = Reader.GetInt32(2);
                DateTime vreme = getDateTimeFromTime(Reader.GetString(3), datum.Year, datum.Month, datum.Day);
                double kg_1_klasa = Reader.GetDouble(4);
                double kg_2_klasa = Reader.GetDouble(5);
                double kg_3_klasa = Reader.GetDouble(6);
                double kg_lisichari = Reader.GetDouble(7);
                double kg_ovchoshapche = Reader.GetDouble(8);
                double kg_rujnica = Reader.GetDouble(9);
                int kolku_plateno = Reader.GetInt32(10);
                int dolzhi = Reader.GetInt32(11);
                int dolzhime = Reader.GetInt32(12);

                CustomerDay cd = new CustomerDay(berach, datum, den_promena_cena, vreme, kg_1_klasa,
                    kg_2_klasa, kg_3_klasa, kg_lisichari, kg_ovchoshapche, kg_rujnica, kolku_plateno, dolzhi, dolzhime);

                list.Add(cd);
            }
            connection.Close();

            return list;
        }

        public static List<CustomerDay> getCustomerDayFromDate(DateTime datum) {
            List<CustomerDay> list = new List<CustomerDay>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from berach_den where den_datum = \"" +
                datum.Year + "-" + datum.Month + "-" + datum.Day + "\"";

            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                int berach = Reader.GetInt32(0);
                int den_promena_cena = Reader.GetInt32(2);
                DateTime vreme = getDateTimeFromTime(Reader.GetString(3), datum.Year, datum.Month, datum.Day);
                double kg_1_klasa = Reader.GetDouble(4);
                double kg_2_klasa = Reader.GetDouble(5);
                double kg_3_klasa = Reader.GetDouble(6);
                double kg_lisichari = Reader.GetDouble(7);
                double kg_ovchoshapche = Reader.GetDouble(8);
                double kg_rujnica = Reader.GetDouble(9);
                int kolku_plateno = Reader.GetInt32(10);
                int dolzhi = Reader.GetInt32(11);
                int dolzhime = Reader.GetInt32(12);

                CustomerDay cd = new CustomerDay(berach, datum, den_promena_cena, vreme, kg_1_klasa,
                    kg_2_klasa, kg_3_klasa, kg_lisichari, kg_ovchoshapche, kg_rujnica, kolku_plateno, dolzhi, dolzhime);

                list.Add(cd);
            }
            connection.Close();

            return list;
        }

        public static List<CustomerDay> getCustomerDayForCustomerUnfinished(Customer c) {
            List<CustomerDay> list = new List<CustomerDay>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from berach_den where berach = \"" + c.id + "\" and (dolzhi > 0 or dolzhime > 0)";

            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                DateTime den_datum = Reader.GetDateTime(1);
                int den_promena_cena = Reader.GetInt32(2);
                DateTime vreme = getDateTimeFromTime(Reader.GetString(3), den_datum.Year, den_datum.Month, den_datum.Day);
                double kg_1_klasa = Reader.GetDouble(4);
                double kg_2_klasa = Reader.GetDouble(5);
                double kg_3_klasa = Reader.GetDouble(6);
                double kg_lisichari = Reader.GetDouble(7);
                double kg_ovchoshapche = Reader.GetDouble(8);
                double kg_rujnica = Reader.GetDouble(9);
                int kolku_plateno = Reader.GetInt32(10);
                int dolzhi = Reader.GetInt32(11);
                int dolzhime = Reader.GetInt32(12);

                CustomerDay cd = new CustomerDay(c.id, den_datum, den_promena_cena, vreme, kg_1_klasa,
                    kg_2_klasa, kg_3_klasa, kg_lisichari, kg_ovchoshapche, kg_rujnica, kolku_plateno, dolzhi, dolzhime);

                list.Add(cd);
            }
            connection.Close();

            return list;
        }

        public static List<CustomerDay> getCustomerDayForCustomer(Customer c) {
            List<CustomerDay> list = new List<CustomerDay>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from berach_den where berach = \"" + c.id + "\"";

            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                DateTime den_datum = Reader.GetDateTime(1);
                int den_promena_cena = Reader.GetInt32(2);
                DateTime vreme = getDateTimeFromTime(Reader.GetString(3), den_datum.Year, den_datum.Month, den_datum.Day);
                double kg_1_klasa = Reader.GetDouble(4);
                double kg_2_klasa = Reader.GetDouble(5);
                double kg_3_klasa = Reader.GetDouble(6);
                double kg_lisichari = Reader.GetDouble(7);
                double kg_ovchoshapche = Reader.GetDouble(8);
                double kg_rujnica = Reader.GetDouble(9);
                int kolku_plateno = Reader.GetInt32(10);
                int dolzhi = Reader.GetInt32(11);
                int dolzhime = Reader.GetInt32(12);

                CustomerDay cd = new CustomerDay(c.id, den_datum, den_promena_cena, vreme, kg_1_klasa,
                    kg_2_klasa, kg_3_klasa, kg_lisichari, kg_ovchoshapche, kg_rujnica, kolku_plateno, dolzhi, dolzhime);

                list.Add(cd);
            }
            connection.Close();

            return list;
        }

        public static List<CustomerDay> getCustomerDayFromPrimaryKey(int berach, DateTime datum, int promena_cena) {
            List<CustomerDay> list = new List<CustomerDay>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from berach_den where berach = \"" + berach + "\" and den_datum = \"" +
                datum.Year + "-" + datum.Month + "-" + datum.Day + "\" and den_promena_cena = \"" +
                promena_cena + "\"";

            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {

                DateTime vreme = getDateTimeFromTime(Reader.GetString(3), datum.Year, datum.Month, datum.Day);
                double kg_1_klasa = Reader.GetDouble(4);
                double kg_2_klasa = Reader.GetDouble(5);
                double kg_3_klasa = Reader.GetDouble(6);
                double kg_lisichari = Reader.GetDouble(7);
                double kg_ovchoshapche = Reader.GetDouble(8);
                double kg_rujnica = Reader.GetDouble(9);
                int kolku_plateno = Reader.GetInt32(10);
                int dolzhi = Reader.GetInt32(11);
                int dolzhime = Reader.GetInt32(12);

                CustomerDay cd = new CustomerDay(berach, datum, promena_cena, vreme, kg_1_klasa,
                    kg_2_klasa, kg_3_klasa, kg_lisichari, kg_ovchoshapche, kg_rujnica, kolku_plateno, dolzhi, dolzhime);

                list.Add(cd);
            }
            connection.Close();

            return list;
        }

        public static void updateCustomerDayRemoveUnfinished(Customer c) {
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "update berach_den set dolzhi = 0, dolzhime = 0 where berach = \"" + c.id + "\"";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        public static void insertIntoCustomerDay(CustomerDay cd) {
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "insert into berach_den values (\"" + cd.berach + "\", \"" + cd.den_datum.Year + "-" + 
                cd.den_datum.Month + "-" + cd.den_datum.Day + "\", \"" + 
                cd.den_promena_cena + "\", \"" + cd.vreme.Hour + ":" + cd.vreme.Minute + ":" + cd.vreme.Second + 
                "\", \"" + cd.kg_1_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + 
                "\", \"" + cd.kg_2_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", \"" + cd.kg_3_klasa + "\", \"" + cd.kg_lisichari + 
                "\", \"" + cd.kg_ovchoshapche.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + 
                "\", \"" + cd.kg_rujnica.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", \"" + 
                cd.kolku_plateno + "\", \"" + 
                cd.dolzhi + "\", \"" + cd.dolzhime + "\")";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        public static List<CustomerDay> getEverythingFromCustomerDay() {
            List<CustomerDay> list = new List<CustomerDay>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from berach_den";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {

                int berach = Reader.GetInt32(0);
                DateTime den_datum = Reader.GetDateTime(1);
                int den_promena_cena = Reader.GetInt32(2);
                DateTime vreme = getDateTimeFromTime(Reader.GetString(3), den_datum.Year, den_datum.Month, den_datum.Day);
                double kg_1_klasa = Reader.GetDouble(4);
                double kg_2_klasa = Reader.GetDouble(5);
                double kg_3_klasa = Reader.GetDouble(6);
                double kg_lisichari = Reader.GetDouble(7);
                double kg_ovchoshapche = Reader.GetDouble(8);
                double kg_rujnica = Reader.GetDouble(9);
                int kolku_plateno = Reader.GetInt32(10);
                int dolzhi = Reader.GetInt32(11);
                int dolzhime = Reader.GetInt32(12);

                CustomerDay cd = new CustomerDay(berach, den_datum, den_promena_cena, vreme, kg_1_klasa,
                    kg_2_klasa, kg_3_klasa, kg_lisichari, kg_ovchoshapche, kg_rujnica, kolku_plateno, dolzhi, dolzhime);

                list.Add(cd);
            }
            connection.Close();

            return list;
        }

        public static Day getDaysFromPrimaryKey(DateTime datum, int promena_cena) {
            List<Day> list = new List<Day>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from den where datum = \"" + datum.Year + 
                "-" + datum.Month + "-" + datum.Day + "\" and promena_cena = \"" + promena_cena + "\"";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                int kupovna_cena_1_klasa = Reader.GetInt32(2);
                int prodazhna_cena_1_klasa = Reader.GetInt32(3);
                int kupovna_cena_2_klasa = Reader.GetInt32(4);
                int prodazhna_cena_2_klasa = Reader.GetInt32(5);
                int kupovna_cena_lisichari = Reader.GetInt32(6);
                int prodazhna_cena_lisichari = Reader.GetInt32(7);
                int kupovna_cena_ovchoshapche = Reader.GetInt32(8);
                int prodazhna_cena_ovchoshapche = Reader.GetInt32(9);
                int kupovna_cena_rujnica = Reader.GetInt32(10);
                int prodazhna_cena_rujnica = Reader.GetInt32(11);
                int kupovna_cena_3_klasa = Reader.GetInt32(12);
                int prodazhna_cena_3_klasa = Reader.GetInt32(13);
                double isprateno_kg_1_klasa = Reader.GetDouble(14);
                double isprateno_kg_2_klasa = Reader.GetDouble(15);
                double isprateno_kg_3_klasa = Reader.GetDouble(16);
                double isprateno_kg_lisichari = Reader.GetDouble(17);
                double isprateno_kg_ovchoshapche = Reader.GetDouble(18);
                double isprateno_kg_rujnica = Reader.GetDouble(19);
                double prodadeno_kg_1_klasa = Reader.GetDouble(20);
                double prodadeno_kg_2_klasa = Reader.GetDouble(21);
                double prodadeno_kg_3_klasa = Reader.GetDouble(22);
                double prodadeno_kg_lisichari = Reader.GetDouble(23);
                double prodadeno_kg_ovchoshapche = Reader.GetDouble(24);
                double prodadeno_kg_rujnica = Reader.GetDouble(25);
                bool zavrshen_den = Reader.GetBoolean(26);

                Day d = new Day(datum, promena_cena, kupovna_cena_1_klasa, prodazhna_cena_1_klasa, kupovna_cena_2_klasa,
                    prodazhna_cena_2_klasa, kupovna_cena_lisichari, prodazhna_cena_lisichari, kupovna_cena_ovchoshapche,
                    prodazhna_cena_ovchoshapche, kupovna_cena_rujnica, prodazhna_cena_rujnica, kupovna_cena_3_klasa,
                    prodazhna_cena_3_klasa, isprateno_kg_1_klasa, isprateno_kg_2_klasa, isprateno_kg_3_klasa,
                    isprateno_kg_lisichari, isprateno_kg_ovchoshapche, isprateno_kg_rujnica, prodadeno_kg_1_klasa,
                    prodadeno_kg_2_klasa, prodadeno_kg_3_klasa, prodadeno_kg_lisichari, prodadeno_kg_ovchoshapche,
                    prodadeno_kg_rujnica, zavrshen_den);

                list.Add(d);
            }
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public static void insertIntoDays(Day d) {
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "insert into den values (\"" + d.date.Year + "-" + d.date.Month + "-" + d.date.Day + 
                "\", \"" + d.promena_cena + "\", \"" + d.kupovna_cena_1_klasa + "\", \"" + d.prodazhna_cena_1_klasa + "\", \"" + 
                d.kupovna_cena_2_klasa + "\", \"" + d.prodazhna_cena_2_klasa + "\", \"" + d.kupovna_cena_lisichari + "\", \"" +
                d.prodazhna_cena_lisichari + "\", \"" + d.kupovna_cena_ovchoshapche + "\", \"" + d.prodazhna_cena_ovchoshapche
                + "\", \"" + d.kupovna_cena_rujnica + "\", \"" + d.prodazhna_cena_rujnica + "\", \"" + d.kupovna_cena_3_klasa 
                + "\", \"" + d.prodazhna_cena_3_klasa + "\", \"" + 
                d.isprateno_kg_1_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", \"" + 
                d.isprateno_kg_2_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                + "\", \"" + d.isprateno_kg_3_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                + "\", \"" + d.isprateno_kg_lisichari.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                + "\", \"" + d.isprateno_kg_ovchoshapche.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                + "\", \"" + d.isprateno_kg_rujnica.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", \"" + 
                d.prodadeno_kg_1_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", \"" + 
                d.prodadeno_kg_2_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                + "\", \"" + d.prodadeno_kg_3_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", \"" + 
                d.prodadeno_kg_lisichari.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", \"" + 
                d.prodadeno_kg_ovchoshapche.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                + "\", \"" + d.prodadeno_kg_rujnica.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                + "\", \"" + (d.zavrshen_den ? 1 : 0) + "\")";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void updateDays(Day d) {
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "update den set " +
                "kupovna_cena_1_klasa = \"" + d.kupovna_cena_1_klasa + "\", " +
                "prodazhna_cena_1_klasa = \"" + d.prodazhna_cena_1_klasa + "\", " +
                "kupovna_cena_2_klasa = \"" + d.kupovna_cena_2_klasa + "\", " +
                "prodazhna_cena_2_klasa = \"" + d.prodazhna_cena_2_klasa + "\", " +
                "kupovna_cena_lisichari = \"" + d.kupovna_cena_lisichari + "\", " +
                "prodazhna_cena_lisichari = \"" + d.prodazhna_cena_lisichari + "\", " +
                "kupovna_cena_ovchoshapche = \"" + d.kupovna_cena_ovchoshapche + "\", " +
                "prodazhna_cena_ovchoshapche = \"" + d.prodazhna_cena_ovchoshapche + "\", " +
                "kupovna_cena_rujnica = \"" + d.kupovna_cena_rujnica + "\", " +
                "prodazhna_cena_rujnica = \"" + d.prodazhna_cena_rujnica + "\", " +
                "kupovna_cena_3_klasa = \"" + d.kupovna_cena_3_klasa + "\", " +
                "prodazhna_cena_3_klasa = \"" + d.prodazhna_cena_3_klasa + "\", " +
                "isprateno_kg_1_klasa = \"" + d.isprateno_kg_1_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "isprateno_kg_2_klasa = \"" + d.isprateno_kg_2_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "isprateno_kg_3_klasa = \"" + d.isprateno_kg_3_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "isprateno_kg_lisichari = \"" + d.isprateno_kg_lisichari.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "isprateno_kg_ovchoshapche = \"" + d.isprateno_kg_ovchoshapche.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "isprateno_kg_rujnica = \"" + d.isprateno_kg_rujnica.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "prodadeno_kg_1_klasa = \"" + d.prodadeno_kg_1_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "prodadeno_kg_2_klasa = \"" + d.prodadeno_kg_2_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "prodadeno_kg_3_klasa = \"" + d.prodadeno_kg_3_klasa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "prodadeno_kg_lisichari = \"" + d.prodadeno_kg_lisichari.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "prodadeno_kg_ovchoshapche = \"" + d.prodadeno_kg_ovchoshapche.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "prodadeno_kg_rujnica = \"" + d.prodadeno_kg_rujnica.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "\", " +
                "zavrshen_den = \"" + (d.zavrshen_den ? 1 : 0) + "\" " + 
                "where " +
                "datum = \"" + d.date.Year + "-" + d.date.Month + "-" + d.date.Day + "\" and " +
                "promena_cena = \"" + d.promena_cena + "\"";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static List<Day> getAllDays() {
            List<Day> list = new List<Day>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from den";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                DateTime date = Reader.GetDateTime(0);
                int promena_cena = Reader.GetInt32(1);
                int kupovna_cena_1_klasa = Reader.GetInt32(2);
                int prodazhna_cena_1_klasa = Reader.GetInt32(3);
                int kupovna_cena_2_klasa = Reader.GetInt32(4);
                int prodazhna_cena_2_klasa = Reader.GetInt32(5);
                int kupovna_cena_lisichari = Reader.GetInt32(6);
                int prodazhna_cena_lisichari = Reader.GetInt32(7);
                int kupovna_cena_ovchoshapche = Reader.GetInt32(8);
                int prodazhna_cena_ovchoshapche = Reader.GetInt32(9);
                int kupovna_cena_rujnica = Reader.GetInt32(10);
                int prodazhna_cena_rujnica = Reader.GetInt32(11);
                int kupovna_cena_3_klasa = Reader.GetInt32(12);
                int prodazhna_cena_3_klasa = Reader.GetInt32(13);
                double isprateno_kg_1_klasa = Reader.GetDouble(14);
                double isprateno_kg_2_klasa = Reader.GetDouble(15);
                double isprateno_kg_3_klasa = Reader.GetDouble(16);
                double isprateno_kg_lisichari = Reader.GetDouble(17);
                double isprateno_kg_ovchoshapche = Reader.GetDouble(18);
                double isprateno_kg_rujnica = Reader.GetDouble(19);
                double prodadeno_kg_1_klasa = Reader.GetDouble(20);
                double prodadeno_kg_2_klasa = Reader.GetDouble(21);
                double prodadeno_kg_3_klasa = Reader.GetDouble(22);
                double prodadeno_kg_lisichari = Reader.GetDouble(23);
                double prodadeno_kg_ovchoshapche = Reader.GetDouble(24);
                double prodadeno_kg_rujnica = Reader.GetDouble(25);
                bool zavrshen_den = Reader.GetBoolean(26);

                Day d = new Day(date, promena_cena, kupovna_cena_1_klasa, prodazhna_cena_1_klasa, kupovna_cena_2_klasa,
                    prodazhna_cena_2_klasa, kupovna_cena_lisichari, prodazhna_cena_lisichari, kupovna_cena_ovchoshapche,
                    prodazhna_cena_ovchoshapche, kupovna_cena_rujnica, prodazhna_cena_rujnica, kupovna_cena_3_klasa,
                    prodazhna_cena_3_klasa, isprateno_kg_1_klasa, isprateno_kg_2_klasa, isprateno_kg_3_klasa,
                    isprateno_kg_lisichari, isprateno_kg_ovchoshapche, isprateno_kg_rujnica, prodadeno_kg_1_klasa,
                    prodadeno_kg_2_klasa, prodadeno_kg_3_klasa, prodadeno_kg_lisichari, prodadeno_kg_ovchoshapche,
                    prodadeno_kg_rujnica, zavrshen_den);

                list.Add(d);
            }

            return list;
        }

        public static Day getLastDay() {
            List<Day> list = new List<Day>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from den order by datum desc, promena_cena desc limit 1";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                DateTime date = Reader.GetDateTime(0);
                int promena_cena = Reader.GetInt32(1);
                int kupovna_cena_1_klasa = Reader.GetInt32(2);
                int prodazhna_cena_1_klasa = Reader.GetInt32(3);
                int kupovna_cena_2_klasa = Reader.GetInt32(4);
                int prodazhna_cena_2_klasa = Reader.GetInt32(5);
                int kupovna_cena_lisichari = Reader.GetInt32(6);
                int prodazhna_cena_lisichari = Reader.GetInt32(7);
                int kupovna_cena_ovchoshapche = Reader.GetInt32(8);
                int prodazhna_cena_ovchoshapche = Reader.GetInt32(9);
                int kupovna_cena_rujnica = Reader.GetInt32(10);
                int prodazhna_cena_rujnica = Reader.GetInt32(11);
                int kupovna_cena_3_klasa = Reader.GetInt32(12);
                int prodazhna_cena_3_klasa = Reader.GetInt32(13);
                double isprateno_kg_1_klasa = Reader.GetDouble(14);
                double isprateno_kg_2_klasa = Reader.GetDouble(15);
                double isprateno_kg_3_klasa = Reader.GetDouble(16);
                double isprateno_kg_lisichari = Reader.GetDouble(17);
                double isprateno_kg_ovchoshapche = Reader.GetDouble(18);
                double isprateno_kg_rujnica = Reader.GetDouble(19);
                double prodadeno_kg_1_klasa = Reader.GetDouble(20);
                double prodadeno_kg_2_klasa = Reader.GetDouble(21);
                double prodadeno_kg_3_klasa = Reader.GetDouble(22);
                double prodadeno_kg_lisichari = Reader.GetDouble(23);
                double prodadeno_kg_ovchoshapche = Reader.GetDouble(24);
                double prodadeno_kg_rujnica = Reader.GetDouble(25);
                bool zavrshen_den = Reader.GetBoolean(26);

                Day d = new Day(date, promena_cena, kupovna_cena_1_klasa, prodazhna_cena_1_klasa, kupovna_cena_2_klasa,
                    prodazhna_cena_2_klasa, kupovna_cena_lisichari, prodazhna_cena_lisichari, kupovna_cena_ovchoshapche,
                    prodazhna_cena_ovchoshapche, kupovna_cena_rujnica, prodazhna_cena_rujnica, kupovna_cena_3_klasa,
                    prodazhna_cena_3_klasa, isprateno_kg_1_klasa, isprateno_kg_2_klasa, isprateno_kg_3_klasa,
                    isprateno_kg_lisichari, isprateno_kg_ovchoshapche, isprateno_kg_rujnica, prodadeno_kg_1_klasa,
                    prodadeno_kg_2_klasa, prodadeno_kg_3_klasa, prodadeno_kg_lisichari, prodadeno_kg_ovchoshapche,
                    prodadeno_kg_rujnica, zavrshen_den);

                list.Add(d);
            }
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public static List<Day> getUnfinishedDays() {
            List<Day> list = new List<Day>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from den where zavrshen_den = 0";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                DateTime date = Reader.GetDateTime(0);
                int promena_cena = Reader.GetInt32(1);
                int kupovna_cena_1_klasa = Reader.GetInt32(2);
                int prodazhna_cena_1_klasa = Reader.GetInt32(3);
                int kupovna_cena_2_klasa = Reader.GetInt32(4);
                int prodazhna_cena_2_klasa = Reader.GetInt32(5);
                int kupovna_cena_lisichari = Reader.GetInt32(6);
                int prodazhna_cena_lisichari = Reader.GetInt32(7);
                int kupovna_cena_ovchoshapche = Reader.GetInt32(8);
                int prodazhna_cena_ovchoshapche = Reader.GetInt32(9);
                int kupovna_cena_rujnica = Reader.GetInt32(10);
                int prodazhna_cena_rujnica = Reader.GetInt32(11);
                int kupovna_cena_3_klasa = Reader.GetInt32(12);
                int prodazhna_cena_3_klasa = Reader.GetInt32(13);
                double isprateno_kg_1_klasa = Reader.GetDouble(14);
                double isprateno_kg_2_klasa = Reader.GetDouble(15);
                double isprateno_kg_3_klasa = Reader.GetDouble(16);
                double isprateno_kg_lisichari = Reader.GetDouble(17);
                double isprateno_kg_ovchoshapche = Reader.GetDouble(18);
                double isprateno_kg_rujnica = Reader.GetDouble(19);
                double prodadeno_kg_1_klasa = Reader.GetDouble(20);
                double prodadeno_kg_2_klasa = Reader.GetDouble(21);
                double prodadeno_kg_3_klasa = Reader.GetDouble(22);
                double prodadeno_kg_lisichari = Reader.GetDouble(23);
                double prodadeno_kg_ovchoshapche = Reader.GetDouble(24);
                double prodadeno_kg_rujnica = Reader.GetDouble(25);
                bool zavrshen_den = Reader.GetBoolean(26);

                Day d = new Day(date, promena_cena, kupovna_cena_1_klasa, prodazhna_cena_1_klasa, kupovna_cena_2_klasa,
                    prodazhna_cena_2_klasa, kupovna_cena_lisichari, prodazhna_cena_lisichari, kupovna_cena_ovchoshapche,
                    prodazhna_cena_ovchoshapche, kupovna_cena_rujnica, prodazhna_cena_rujnica, kupovna_cena_3_klasa,
                    prodazhna_cena_3_klasa, isprateno_kg_1_klasa, isprateno_kg_2_klasa, isprateno_kg_3_klasa,
                    isprateno_kg_lisichari, isprateno_kg_ovchoshapche, isprateno_kg_rujnica, prodadeno_kg_1_klasa,
                    prodadeno_kg_2_klasa, prodadeno_kg_3_klasa, prodadeno_kg_lisichari, prodadeno_kg_ovchoshapche,
                    prodadeno_kg_rujnica, zavrshen_den);

                list.Add(d);
            }

            return list;
        }

        public static List<Day> getAllDaysForMonth(DateTime dt) {
            List<Day> list = new List<Day>();

            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from den where (datum between \"" + dt.Year + "-" + 
                dt.Month + "-" + 1 + "\" and \"" + dt.Year + "-" + (dt.Month + 1) + "-" + 1 + "\")";
            connection.Open();
            MySqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read()) {
                DateTime date = Reader.GetDateTime(0);
                int promena_cena = Reader.GetInt32(1);
                int kupovna_cena_1_klasa = Reader.GetInt32(2);
                int prodazhna_cena_1_klasa = Reader.GetInt32(3);
                int kupovna_cena_2_klasa = Reader.GetInt32(4);
                int prodazhna_cena_2_klasa = Reader.GetInt32(5);
                int kupovna_cena_lisichari = Reader.GetInt32(6);
                int prodazhna_cena_lisichari = Reader.GetInt32(7);
                int kupovna_cena_ovchoshapche = Reader.GetInt32(8);
                int prodazhna_cena_ovchoshapche = Reader.GetInt32(9);
                int kupovna_cena_rujnica = Reader.GetInt32(10);
                int prodazhna_cena_rujnica = Reader.GetInt32(11);
                int kupovna_cena_3_klasa = Reader.GetInt32(12);
                int prodazhna_cena_3_klasa = Reader.GetInt32(13);
                double isprateno_kg_1_klasa = Reader.GetDouble(14);
                double isprateno_kg_2_klasa = Reader.GetDouble(15);
                double isprateno_kg_3_klasa = Reader.GetDouble(16);
                double isprateno_kg_lisichari = Reader.GetDouble(17);
                double isprateno_kg_ovchoshapche = Reader.GetDouble(18);
                double isprateno_kg_rujnica = Reader.GetDouble(19);
                double prodadeno_kg_1_klasa = Reader.GetDouble(20);
                double prodadeno_kg_2_klasa = Reader.GetDouble(21);
                double prodadeno_kg_3_klasa = Reader.GetDouble(22);
                double prodadeno_kg_lisichari = Reader.GetDouble(23);
                double prodadeno_kg_ovchoshapche = Reader.GetDouble(24);
                double prodadeno_kg_rujnica = Reader.GetDouble(25);
                bool zavrshen_den = Reader.GetBoolean(26);

                Day d = new Day(date, promena_cena, kupovna_cena_1_klasa, prodazhna_cena_1_klasa, kupovna_cena_2_klasa,
                    prodazhna_cena_2_klasa, kupovna_cena_lisichari, prodazhna_cena_lisichari, kupovna_cena_ovchoshapche,
                    prodazhna_cena_ovchoshapche, kupovna_cena_rujnica, prodazhna_cena_rujnica, kupovna_cena_3_klasa,
                    prodazhna_cena_3_klasa, isprateno_kg_1_klasa, isprateno_kg_2_klasa, isprateno_kg_3_klasa,
                    isprateno_kg_lisichari, isprateno_kg_ovchoshapche, isprateno_kg_rujnica, prodadeno_kg_1_klasa,
                    prodadeno_kg_2_klasa, prodadeno_kg_3_klasa, prodadeno_kg_lisichari, prodadeno_kg_ovchoshapche,
                    prodadeno_kg_rujnica, zavrshen_den);

                list.Add(d);
            }

            return list;
        }

        public static CustomerEntry getEntriesForCustomer(string name) {
            CustomerEntry l = new CustomerEntry();

            int id = getIDForCustomer(name);

            Customer c = new Customer(id, name);

            List<CustomerDay> cd = getCustomerDayForCustomer(c);

            l.entries = cd;
            l.customer = c;


            return l;
        }

    }
}
