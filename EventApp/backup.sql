--
-- PostgreSQL database dump
--

-- Dumped from database version 16.4 (Debian 16.4-1.pgdg120+1)
-- Dumped by pg_dump version 16.4 (Debian 16.4-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: CategoryOfEventEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."CategoryOfEventEntities" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL
);


ALTER TABLE public."CategoryOfEventEntities" OWNER TO postgres;

--
-- Name: EventEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."EventEntities" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Description" text NOT NULL,
    "Date" timestamp with time zone NOT NULL,
    "Location" text NOT NULL,
    "CategoryId" uuid NOT NULL,
    "MaxNumberOfMembers" integer NOT NULL,
    "ImageUrl" text NOT NULL
);


ALTER TABLE public."EventEntities" OWNER TO postgres;

--
-- Name: MemberOfEventEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."MemberOfEventEntities" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "LastName" text NOT NULL,
    "Birthday" timestamp with time zone NOT NULL,
    "DateOfRegistration" timestamp with time zone NOT NULL,
    "Email" text NOT NULL,
    "UserId" uuid NOT NULL,
    "EventId" uuid NOT NULL
);


ALTER TABLE public."MemberOfEventEntities" OWNER TO postgres;

--
-- Name: RefreshTokenEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RefreshTokenEntities" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Token" text NOT NULL,
    "Expires" timestamp with time zone NOT NULL
);


ALTER TABLE public."RefreshTokenEntities" OWNER TO postgres;

--
-- Name: UserEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserEntities" (
    "Id" uuid NOT NULL,
    "UserName" text NOT NULL,
    "UserEmail" text NOT NULL,
    "Password" text NOT NULL,
    "Role" text NOT NULL
);


ALTER TABLE public."UserEntities" OWNER TO postgres;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: CategoryOfEventEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."CategoryOfEventEntities" ("Id", "Title") FROM stdin;
12332915-2505-4089-9f4b-7a1efbea8620	╨Я╤А╨░╨╖╨┤╨╜╨╕╨║
c06ccd8b-8360-4305-8e49-d97275dc8748	╨Ъ╨╛╨╜╤Д╨╡╤А╨╡╨╜╤Ж╨╕╤П
\.


--
-- Data for Name: EventEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."EventEntities" ("Id", "Title", "Description", "Date", "Location", "CategoryId", "MaxNumberOfMembers", "ImageUrl") FROM stdin;
eca391cf-591f-4eb5-8358-18a096130385	╨Ъ╨╛╨╜╤Д╨╡╤А╨╡╨╜╤Ж╨╕╤П AI	╨а╨░╤Б╤Б╨║╨░╨╢╤Г╤В ╨┐╤А╨╛ ╨╕╤Б╨║╤Г╤Б╤Б╤В╨▓╨╡╨╜╨╜╤Л╨╣ ╨╕╨╜╤В╨╡╨╗╨╗╨╡╨║╤В	2024-09-26 19:27:42.791+00	Minsk	c06ccd8b-8360-4305-8e49-d97275dc8748	50	
46cdd408-7875-485c-bc64-45491ea9ce13	Day of city	big sdfsdfsdfsdfsd	2024-09-29 19:27:42.791+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	50	
9c38f476-8170-4e77-9721-696da3b39921	Art Exhibition	Local artists showcase their work	2024-10-10 10:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	35	
bb660a56-2d0f-4e0b-97b7-bf8b0db4e2a2	Tech Conference	Latest trends in technology	2024-11-05 09:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	40	
c572bf60-f485-494a-9624-52c080c3e56a	Jazz Night	Evening of live jazz music	2024-09-30 19:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	45	
25dc3f5e-fd54-4641-bf58-73dd639c2811	Book Fair	Annual book fair for literature lovers	2024-12-15 12:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	50	
47c83f80-3a0f-4f94-90cf-1fbba04cafe3	Food Festival	Taste dishes from around the world	2024-09-28 13:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	30	
13ab83d8-7f8f-4f80-a659-cd3af8d9bc4a	Fitness Challenge	Participate in various fitness activities	2024-10-20 07:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	37	
5aa72947-1605-4b08-b59f-58cc9d4c30f2	Coding Bootcamp	Learn programming in one day	2024-10-15 08:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	32	
f76933fc-f15f-4a4d-b556-b2b0a85f7bb0	Photography Workshop	Improve your photography skills	2024-11-03 10:30:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	39	
ae5bcf7f-83b7-44d0-bd7a-abb8b0741fc8	Startup Pitch Night	Watch startups pitch their ideas	2024-12-10 18:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	44	
5e3c768b-64c1-4d82-9e7e-25bb4d4dbe5b	Yoga Retreat	Day-long relaxation and meditation	2024-11-25 09:30:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	33	
7d2c7742-0d0f-4b7c-b71d-9b1b113e0e62	Charity Marathon	Run for a good cause	2024-09-26 07:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	47	
fdc08e82-63a3-44f1-8a43-4b38f5a129bb	Fashion Show	Discover new fashion trends	2024-10-05 19:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	36	
244f1f98-c516-46f9-b37b-34a67ff06c95	Music Festival	Two-day event of live music performances	2024-09-27 16:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	31	
ee4c4041-d5b1-4b84-9d09-30a57928d6db	Environmental Awareness Day	Learn about sustainable living	2024-11-20 11:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	48	
b9e03368-7700-43c7-a1b0-83f8dc342888	Stand-up Comedy Night	Laugh out loud with local comedians	2024-12-02 20:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	34	
995472a9-21cb-41d3-b0c5-3d0a8f84d6f7	Wine Tasting	Sample a variety of wines	2024-11-12 18:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	42	
9ac147b7-73d5-4ae9-9b97-f3f9e1c6babc	Classical Concert	Evening of classical music	2024-10-18 19:30:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	49	
3f75c6b5-bd30-4aa3-8c55-96a178d3c674	Photography Exhibition	Explore the works of renowned photographers	2024-09-25 10:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	46	
d7e30678-b69f-48f5-bb84-33c51d2ac6f6	Robotics Competition	Watch teams compete with their robots	2024-10-22 09:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	41	
70f4c0e9-d1e1-4b78-82c3-1034e891de9a	Cooking Masterclass	Learn to cook gourmet dishes	2024-11-18 15:00:00+00	Minsk	12332915-2505-4089-9f4b-7a1efbea8620	50	
\.


--
-- Data for Name: MemberOfEventEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."MemberOfEventEntities" ("Id", "Name", "LastName", "Birthday", "DateOfRegistration", "Email", "UserId", "EventId") FROM stdin;
52ae0c11-1cca-4641-8387-647484b11fb5	╨Я╨╡╤В╤А	╨Я╨╡╤В╤А╨╛╨▓╨╕╤З	2004-09-19 21:36:42.641+00	2024-09-19 21:38:17.476343+00	Petr@gmail.com	33fe3b5e-d56e-4d73-8f6d-f1750e43e00a	3f75c6b5-bd30-4aa3-8c55-96a178d3c674
\.


--
-- Data for Name: RefreshTokenEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RefreshTokenEntities" ("Id", "UserId", "Token", "Expires") FROM stdin;
b5441043-542d-4b57-ac63-3ad37b7cd767	2635b7d5-aa3c-41c2-a7c5-a4f57b5e6ed8	saqiR97FGdqd47CRZ/mGOmx3yl+58FYxqAM9SrJI/047KfXJjdhyR7nLxc9e40xWWXPT3Tg8Wlzmz8HKFdSNTQ==	2024-09-25 20:10:18.31698+00
6250604d-e3d3-40c1-9f8b-ec5c8f8c7f34	10fb35c8-195a-44c5-9b05-9508b02fe306	reC4e9NUBOMYQslNA9k57eTQ9rLYvB1L6ruUSPyslg72MgUUYiqNGxVv+cN0ZkHm4EadH9G4mT8c83i39X31UA==	2024-09-25 23:56:11.388872+00
1de34e6e-83e8-434a-a2f1-02d8b35c54af	33fe3b5e-d56e-4d73-8f6d-f1750e43e00a	0wtZeRO3ocsz9qHHsuzfRZj4J0zirLWOgfZAvd0EaFZMbgFbpG0Q/l/2PLu1Q+yOt96XEO0PsbQBVVR2EdwflA==	2024-09-26 19:58:00.599964+00
\.


--
-- Data for Name: UserEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserEntities" ("Id", "UserName", "UserEmail", "Password", "Role") FROM stdin;
33fe3b5e-d56e-4d73-8f6d-f1750e43e00a	admin	admin@gmail.com	$2a$11$TRH4fGaDKy7v3Jojx13geu0p4KQyC.tFWwIY.MMAXIvImQJASXFze	Admin
aa98df8f-76ae-468c-9265-61194d6be65d	string	string	$2a$11$Sb7liH1dbcKYIzvX6erFJOi6eLv4dtGbnTFgJjzDhXaUcEKK/sOD.	string
2635b7d5-aa3c-41c2-a7c5-a4f57b5e6ed8	user	user	$2a$11$Jy4beqj4IiBdeIeAFi674euyTp2HPJQTYhCNM9BX1Bd0qkjfsKQoO	User
593ae096-f6b6-4f7b-abf4-498a4bd46c85	TestUser	testuset@gmail.com	$2a$11$YTBYjxqvAE5otxpceCU5eunmugOW6rFusPeYs5Z5V0FzYA4mteeKe	User
10fb35c8-195a-44c5-9b05-9508b02fe306	NewUser	NewUser@gmail.com	$2a$11$E3pHKxt2lldFZl37MqA.C.TEak8zjTj19Y0QVBnBEYsJMEoidutR2	User
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20240916162353_init	8.0.8
20240916201323_RefreshTokenUpdate	8.0.8
\.


--
-- Name: CategoryOfEventEntities PK_CategoryOfEventEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CategoryOfEventEntities"
    ADD CONSTRAINT "PK_CategoryOfEventEntities" PRIMARY KEY ("Id");


--
-- Name: EventEntities PK_EventEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EventEntities"
    ADD CONSTRAINT "PK_EventEntities" PRIMARY KEY ("Id");


--
-- Name: MemberOfEventEntities PK_MemberOfEventEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberOfEventEntities"
    ADD CONSTRAINT "PK_MemberOfEventEntities" PRIMARY KEY ("Id");


--
-- Name: RefreshTokenEntities PK_RefreshTokenEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshTokenEntities"
    ADD CONSTRAINT "PK_RefreshTokenEntities" PRIMARY KEY ("Id");


--
-- Name: UserEntities PK_UserEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserEntities"
    ADD CONSTRAINT "PK_UserEntities" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_CategoryOfEventEntities_Title; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_CategoryOfEventEntities_Title" ON public."CategoryOfEventEntities" USING btree ("Title");


--
-- Name: IX_EventEntities_CategoryId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_EventEntities_CategoryId" ON public."EventEntities" USING btree ("CategoryId");


--
-- Name: IX_MemberOfEventEntities_EventId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_MemberOfEventEntities_EventId" ON public."MemberOfEventEntities" USING btree ("EventId");


--
-- Name: IX_MemberOfEventEntities_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_MemberOfEventEntities_UserId" ON public."MemberOfEventEntities" USING btree ("UserId");


--
-- Name: IX_RefreshTokenEntities_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_RefreshTokenEntities_UserId" ON public."RefreshTokenEntities" USING btree ("UserId");


--
-- Name: IX_UserEntities_UserEmail; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_UserEntities_UserEmail" ON public."UserEntities" USING btree ("UserEmail");


--
-- Name: IX_UserEntities_UserName; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_UserEntities_UserName" ON public."UserEntities" USING btree ("UserName");


--
-- Name: EventEntities FK_EventEntities_CategoryOfEventEntities_CategoryId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."EventEntities"
    ADD CONSTRAINT "FK_EventEntities_CategoryOfEventEntities_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES public."CategoryOfEventEntities"("Id") ON DELETE RESTRICT;


--
-- Name: MemberOfEventEntities FK_MemberOfEventEntities_EventEntities_EventId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberOfEventEntities"
    ADD CONSTRAINT "FK_MemberOfEventEntities_EventEntities_EventId" FOREIGN KEY ("EventId") REFERENCES public."EventEntities"("Id") ON DELETE CASCADE;


--
-- Name: MemberOfEventEntities FK_MemberOfEventEntities_UserEntities_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberOfEventEntities"
    ADD CONSTRAINT "FK_MemberOfEventEntities_UserEntities_UserId" FOREIGN KEY ("UserId") REFERENCES public."UserEntities"("Id") ON DELETE CASCADE;


--
-- Name: RefreshTokenEntities FK_RefreshTokenEntities_UserEntities_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshTokenEntities"
    ADD CONSTRAINT "FK_RefreshTokenEntities_UserEntities_UserId" FOREIGN KEY ("UserId") REFERENCES public."UserEntities"("Id") ON DELETE RESTRICT;


--
-- PostgreSQL database dump complete
--

