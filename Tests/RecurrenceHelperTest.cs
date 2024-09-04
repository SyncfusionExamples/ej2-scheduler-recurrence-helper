using System;
using Xunit;
using Recurrence.Services;
using System.Collections.Generic;
using Recurrence;

namespace Recurrence.UnitTests.Services;

public class RecurrenceServiceCheck
{
    private List<DateTime> ActualResult(DateTime format, string rule)
    {
        IQueryable<DateTime> ResDates = RecurrenceHelper.GetRecurrenceDateTimeCollection(rule, format);
        return ResDates.Select(d => new DateTime(d.Year, d.Month, d.Day, format.Hour, format.Minute, format.Second)).ToList();
    }

    [Fact]
    public void GetDailyRecurrence()
    {
        //TO CHECK RECURRENCE FREQUENCY DAILY WITH COUNT
        //Interval-1 and count
        List<DateTime> Actual = ActualResult(new DateTime(2019, 1, 1, 13, 0, 0), "FREQ=DAILY;INTERVAL=1;COUNT=10;");
        List<DateTime> Expected = new List<DateTime>
            {
                new DateTime(2019,1,1,13,0,0),new DateTime(2019,1,2,13,0,0),
                new DateTime(2019,1,3,13,0,0),new DateTime(2019,1,4,13,0,0),
                new DateTime(2019,1,5,13,0,0),new DateTime(2019,1,6,13,0,0),
                new DateTime(2019,1,7,13,0,0),new DateTime(2019,1,8,13,0,0),
                new DateTime(2019,1,9,13,0,0),new DateTime(2019,1,10,13,0,0),
            };
        Assert.Equal(Expected, Actual);
        //Interval-2 and count
        List<DateTime> ActualValue = ActualResult(new DateTime(2019, 1, 10, 9, 30, 0), "FREQ=DAILY;INTERVAL=2;COUNT=5;");
        List<DateTime> ExpectedValue = new List<DateTime>
            {
                new DateTime(2019,1,10,9,30,0),
                new DateTime(2019,1,12,9,30,0),
                new DateTime(2019,1,14,9,30,0),
                new DateTime(2019,1,16,9,30,0),
                new DateTime(2019,1,18,9,30,0),
            };
        Assert.Equal(ExpectedValue, ActualValue);
        //Interval-3 and count
        List<DateTime> ActualResults = ActualResult(new DateTime(2019, 3, 15), "FREQ=DAILY;INTERVAL=3;COUNT=7;");
        List<DateTime> ExpectedResults = new List<DateTime>
            {
                new DateTime(2019,3,15),
                new DateTime(2019,3,18),
                new DateTime(2019,3,21),
                new DateTime(2019,3,24),
                new DateTime(2019,3,27),
                new DateTime(2019,3,30),
                new DateTime(2019,4,2),
            };
        Assert.Equal(ExpectedResults, ActualResults);

        //TO CHECK RECURRENCE FREQUENCY DAILY WITH UNTIL
        //Interval-1 and until
        List<DateTime> ActualOutput = ActualResult(new DateTime(2019, 5, 31, 22, 0, 0), "FREQ=DAILY;INTERVAL=1;UNTIL=20190618T000000Z;");
        List<DateTime> ExpectedOutput = new List<DateTime>
            {
                new DateTime(2019,5,31,22,0,0),new DateTime(2019,6,1,22,0,0),
                new DateTime(2019,6,2,22,0,0),new DateTime(2019,6,3,22,0,0),
                new DateTime(2019,6,4,22,0,0),new DateTime(2019,6,5,22,0,0),
                new DateTime(2019,6,6,22,0,0),new DateTime(2019,6,7,22,0,0),
                new DateTime(2019,6,8,22,0,0),new DateTime(2019,6,9,22,0,0),
                new DateTime(2019,6,10,22,0,0),new DateTime(2019,6,11,22,0,0),
                new DateTime(2019,6,12,22,0,0),new DateTime(2019,6,13,22,0,0),
                new DateTime(2019,6,14,22,0,0),new DateTime(2019,6,15,22,0,0),
                new DateTime(2019,6,16,22,0,0),new DateTime(2019,6,17,22,0,0),
                new DateTime(2019,6,18,22,0,0),
            };
        Assert.Equal(ExpectedOutput, ActualOutput);
        //Interval-2 and until
        List<DateTime> ActualVar = ActualResult(new DateTime(2019, 9, 1, 2, 0, 0), "FREQ=DAILY;INTERVAL=2;UNTIL=20190924T000000Z;");
        List<DateTime> ExpectedVar = new List<DateTime>
            {
                new DateTime(2019,9,1,2,0,0),new DateTime(2019,9,3,2,0,0),
                new DateTime(2019,9,5,2,0,0),new DateTime(2019,9,7,2,0,0),
                new DateTime(2019,9,9,2,0,0),new DateTime(2019,9,11,2,0,0),
                new DateTime(2019,9,13,2,0,0),new DateTime(2019,9,15,2,0,0),
                new DateTime(2019,9,17,2,0,0),new DateTime(2019,9,19,2,0,0),
                new DateTime(2019,9,21,2,0,0),new DateTime(2019,9,23,2,0,0),
            };
        Assert.Equal(ExpectedVar, ActualVar);

        //To check daily frequency with never
        //Having DAILY property alone.Other properties are not provided
        List<DateTime> ActualRes = ActualResult(new DateTime(2019, 2, 1), "FREQ=DAILY;INTERVAL=1;");
        List<DateTime> ExpectedRes = new List<DateTime>
            {
                new DateTime(2019, 2, 1),new DateTime(2019, 2, 2),
                new DateTime(2019, 2, 3),new DateTime(2019, 2, 4),
                new DateTime(2019, 2, 5),new DateTime(2019, 2, 6),
                new DateTime(2019, 2, 7),new DateTime(2019, 2, 8),
                new DateTime(2019, 2, 9),new DateTime(2019, 2, 10),
                new DateTime(2019, 2, 11),new DateTime(2019, 2, 12),
                new DateTime(2019, 2, 13),new DateTime(2019, 2, 14),
                new DateTime(2019, 2, 15),new DateTime(2019, 2, 16),
                new DateTime(2019, 2, 17),new DateTime(2019, 2, 18),
                new DateTime(2019, 2, 19),new DateTime(2019, 2, 20),
                new DateTime(2019, 2, 21),new DateTime(2019, 2, 22),
                new DateTime(2019, 2, 23),new DateTime(2019, 2, 24),
                new DateTime(2019, 2, 25),new DateTime(2019, 2, 26),
                new DateTime(2019, 2, 27),new DateTime(2019, 2, 28),
                new DateTime(2019, 3, 1),new DateTime(2019, 3, 2),
                new DateTime(2019, 3, 3),new DateTime(2019, 3, 4),
                new DateTime(2019, 3, 5),new DateTime(2019, 3, 6),
                new DateTime(2019, 3, 7),new DateTime(2019, 3, 8),
                new DateTime(2019, 3, 9),new DateTime(2019, 3, 10),
                new DateTime(2019, 3, 11),new DateTime(2019, 3, 12),
                new DateTime(2019, 3, 13),new DateTime(2019, 3, 14),
                new DateTime(2019, 3, 15),
            };
        Assert.Equal(ExpectedRes, ActualRes);
        // Having DAILY property alone.Other properties are not provided
        List<DateTime> ActualV = ActualResult(new DateTime(2019, 12, 12), "FREQ=DAILY;INTERVAL=2;");
        List<DateTime> ExpectedV = new List<DateTime>
            {
                new DateTime(2019,12,12),new DateTime(2019,12,14),
                new DateTime(2019,12,16),new DateTime(2019,12,18),
                new DateTime(2019,12,20),new DateTime(2019,12,22),
                new DateTime(2019,12,24),new DateTime(2019,12,26),
                new DateTime(2019,12,28),new DateTime(2019,12,30),
                new DateTime(2020,1,1),new DateTime(2020,1,3),
                new DateTime(2020,1,5),new DateTime(2020,1,7),
                new DateTime(2020,1,9),new DateTime(2020,1,11),
                new DateTime(2020,1,13),new DateTime(2020,1,15),
                new DateTime(2020,1,17),new DateTime(2020,1,19),
                new DateTime(2020,1,21),new DateTime(2020,1,23),
                new DateTime(2020,1,25),new DateTime(2020,1,27),
                new DateTime(2020,1,29),new DateTime(2020,1,31),
                new DateTime(2020,2,2),new DateTime(2020,2,4),
                new DateTime(2020,2,6),new DateTime(2020,2,8),
                new DateTime(2020,2,10),new DateTime(2020,2,12),
                new DateTime(2020,2,14),new DateTime(2020,2,16),
                new DateTime(2020,2,18),new DateTime(2020,2,20),
                new DateTime(2020,2,22),new DateTime(2020,2,24),
                new DateTime(2020,2,26),new DateTime(2020,2,28),
                new DateTime(2020,3,1),new DateTime(2020,3,3),
                new DateTime(2020,3,5),
            };
        Assert.Equal(ExpectedV, ActualV);
        // Having DAILY Freq with ByDay
    }

    [Fact]
    public void GetWeeklyRecurrence()
    {

        //TO CHECK RECURRENCE FREQUENCY WEEKLY WITH COUNT
        //Only count
        List<DateTime> Actualvalue = ActualResult(new DateTime(2019, 5, 6, 8, 0, 0), "FREQ=WEEKLY;BYDAY=MO;COUNT=5;");
        List<DateTime> Expectedvalue = new List<DateTime>
            {
                new DateTime(2019,5,6,8,0,0),new DateTime(2019,5,13,8,0,0),
                new DateTime(2019,5,20,8,0,0),new DateTime(2019,5,27,8,0,0),
                new DateTime(2019,6,3,8,0,0)
            };
        Assert.Equal(Expectedvalue, Actualvalue);
        //To check for Frequency without Bydate and day of week is Sunday
        Actualvalue = ActualResult(new DateTime(2020, 1, 5), "FREQ=WEEKLY;BYDAY=SU;COUNT=5;");
        Expectedvalue = new List<DateTime>
            {
                new DateTime(2020, 1, 5, 0, 0, 0),new DateTime(2020, 1, 12, 0, 0, 0),
                new DateTime(2020, 1, 19, 0, 0, 0),new DateTime(2020, 1, 26, 0, 0, 0),
                new DateTime(2020, 2, 2, 0, 0, 0)
            };
        Assert.Equal(Expectedvalue, Actualvalue);
        //To check for Frequency without Bydate and day of week is Tuesday
        Actualvalue = ActualResult(new DateTime(2020, 2, 4), "FREQ=WEEKLY;BYDAY=TU;COUNT=5;");
        Expectedvalue = new List<DateTime>
            {
                new DateTime(2020, 2, 4, 0, 0, 0),new DateTime(2020, 2, 11, 0, 0, 0),
                new DateTime(2020, 2, 18, 0, 0, 0),new DateTime(2020, 2, 25, 0, 0, 0),
                new DateTime(2020, 3, 3, 0, 0, 0)
            };
        Assert.Equal(Expectedvalue, Actualvalue);
        //To check for Frequency without Bydate and day of week is wednesday
        Actualvalue = ActualResult(new DateTime(2020, 3, 18), "FREQ=WEEKLY;BYDAY=WE;COUNT=5;");
        Expectedvalue = new List<DateTime>
            {
                new DateTime(2020, 3, 18, 0, 0, 0),new DateTime(2020, 3, 25, 0, 0, 0),
                new DateTime(2020, 4, 1, 0, 0, 0),new DateTime(2020, 4, 8, 0, 0, 0),
                new DateTime(2020, 4, 15, 0, 0, 0)
            };
        Assert.Equal(Expectedvalue, Actualvalue);
        //To check for Frequency without Bydate and day of week is Thursday
        Actualvalue = ActualResult(new DateTime(2020, 4, 30), "FREQ=WEEKLY;BYDAY=TH;COUNT=5;");
        Expectedvalue = new List<DateTime>
            {
                new DateTime(2020, 4, 30, 0, 0, 0),new DateTime(2020, 5, 7, 0, 0, 0),
                new DateTime(2020, 5, 14, 0, 0, 0),new DateTime(2020, 5, 21, 0, 0, 0),
                new DateTime(2020, 5, 28, 0, 0, 0)
            };
        Assert.Equal(Expectedvalue, Actualvalue);
        //To check for Frequency without Bydate and day of week is friday
        Actualvalue = ActualResult(new DateTime(2020, 5, 15), "FREQ=WEEKLY;BYDAY=FR;COUNT=5;");
        Expectedvalue = new List<DateTime>
            {
                new DateTime(2020, 5, 15, 0, 0, 0),new DateTime(2020, 5, 22, 0, 0, 0),
                new DateTime(2020, 5, 29, 0, 0, 0),new DateTime(2020, 6, 5, 0, 0, 0),
                new DateTime(2020, 6, 12, 0, 0, 0)
            };
        Assert.Equal(Expectedvalue, Actualvalue);
        //To check for Frequency without Bydate and day of week is saturday
        Actualvalue = ActualResult(new DateTime(2020, 7, 11), "FREQ=WEEKLY;BYDAY=SA;COUNT=5;");
        Expectedvalue = new List<DateTime>
            {
                new DateTime(2020, 7, 11, 0, 0, 0),new DateTime(2020, 7, 18, 0, 0, 0),
                new DateTime(2020, 7, 25, 0, 0, 0),new DateTime(2020, 8, 1, 0, 0, 0),
                new DateTime(2020, 8, 8, 0, 0, 0)
            };
        Assert.Equal(Expectedvalue, Actualvalue);
        //ByDay with interval-1 and count
        List<DateTime> Actual = ActualResult(new DateTime(2019, 8, 1, 13, 0, 0), "FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;INTERVAL=1;COUNT=8;");
        List<DateTime> Expected = new List<DateTime>
            {
                new DateTime(2019, 8, 1, 13, 0, 0),
                new DateTime(2019, 8, 2, 13, 0, 0),
                new DateTime(2019, 8, 5, 13, 0, 0),
                new DateTime(2019, 8, 6, 13, 0, 0),
                new DateTime(2019, 8, 7, 13, 0, 0),
                new DateTime(2019, 8, 8, 13, 0, 0),
                new DateTime(2019, 8, 9, 13, 0, 0),
                new DateTime(2019, 8, 12, 13, 0, 0),
            };
        Assert.Equal(Expected, Actual);
        //ByDay with interval-2 and count
        List<DateTime> ActualOutput = ActualResult(new DateTime(2019, 12, 12, 9, 30, 0), "FREQ=WEEKLY;BYDAY=WE;INTERVAL=2;COUNT=13;");
        List<DateTime> ExpectedOutput = new List<DateTime>
            {
                new DateTime(2019,12,25,9,30,0),new DateTime(2020,1,8,9,30,0),
                new DateTime(2020,1, 22, 9, 30, 0),new DateTime(2020,2,5,9,30,0),
                new DateTime(2020,2, 19, 9, 30, 0),new DateTime(2020,3,4,9,30,0),
                new DateTime(2020,3, 18, 9, 30, 0),new DateTime(2020,4,1,9,30,0),
                new DateTime(2020,4, 15, 9, 30, 0),new DateTime(2020,4,29,9,30,0),
                new DateTime(2020,5, 13, 9, 30, 0),new DateTime(2020,5,27,9,30,0),
                new DateTime(2020,6,10,9,30,0),
            };
        Assert.Equal(ExpectedOutput, ActualOutput);
        //ByDay with interval-2 and count
        List<DateTime> Actual_Res = ActualResult(new DateTime(2019, 12, 10, 9, 30, 0), "FREQ=WEEKLY;BYDAY=WE;INTERVAL=2;COUNT=13;");
        List<DateTime> Expected_Res = new List<DateTime>
            {
                new DateTime(2019,12,11,9,30,0),new DateTime(2019,12, 25, 9, 30, 0),
                new DateTime(2020,1,8,9,30,0),new DateTime(2020,1, 22, 9, 30, 0),
                new DateTime(2020,2,5,9,30,0),new DateTime(2020,2, 19, 9, 30, 0),
                new DateTime(2020,3,4,9,30,0),new DateTime(2020,3, 18, 9, 30, 0),
                new DateTime(2020,4,1,9,30,0),new DateTime(2020,4, 15, 9, 30, 0),
                new DateTime(2020,4,29,9,30,0),new DateTime(2020,5, 13, 9, 30, 0),
                new DateTime(2020,5,27,9,30,0),
            };
        Assert.Equal(Expected_Res, Actual_Res);
        //ByDay with interval-3 and count
        List<DateTime> ActualRes = ActualResult(new DateTime(2019, 6, 11, 17, 0, 0), "FREQ=WEEKLY;BYDAY=FR,SA;INTERVAL=3;COUNT=17;");
        List<DateTime> ExpectedRes = new List<DateTime>
            {
                new DateTime(2019,6,14,17,0,0),new DateTime(2019,6,15,17,0,0),
                new DateTime(2019,7,5,17,0,0),new DateTime(2019,7,6,17,0,0),
                new DateTime(2019,7,26,17,0,0),new DateTime(2019,7,27,17,0,0),
                new DateTime(2019,8,16,17,0,0),new DateTime(2019,8,17,17,0,0),
                new DateTime(2019,9,6,17,0,0),new DateTime(2019,9,7,17,0,0),
                new DateTime(2019,9,27,17,0,0),new DateTime(2019,9,28,17,0,0),
                new DateTime(2019,10,18,17,0,0),new DateTime(2019,10,19,17,0,0),
                new DateTime(2019,11,8,17,0,0),new DateTime(2019,11,9,17,0,0),
                new DateTime(2019,11,29,17,0,0),
            };
        Assert.Equal(ExpectedRes, ActualRes);
        //ByDay with interval-1
        List<DateTime> Actualoutput = ActualResult(new DateTime(2019, 2, 14, 13, 0, 0), "FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;INTERVAL=1;");
        List<DateTime> Expectedoutput = new List<DateTime>
            {
                new DateTime(2019,2,14,13,0,0),new DateTime(2019,2,15,13,0,0),
                new DateTime(2019,2,18,13,0,0),new DateTime(2019,2,19,13,0,0),
                new DateTime(2019,2,20,13,0,0),new DateTime(2019,2,21,13,0,0),
                new DateTime(2019,2,22,13,0,0),new DateTime(2019,2,25,13,0,0),
                new DateTime(2019,2,26,13,0,0),new DateTime(2019,2,27,13,0,0),
                new DateTime(2019,2,28,13,0,0),new DateTime(2019,3,1,13,0,0),
                new DateTime(2019,3,4,13,0,0),new DateTime(2019,3,5,13,0,0),
                new DateTime(2019,3,6,13,0,0),new DateTime(2019,3,7,13,0,0),
                new DateTime(2019,3,8,13,0,0),new DateTime(2019,3,11,13,0,0),
                new DateTime(2019,3,12,13,0,0),new DateTime(2019,3,13,13,0,0),
                new DateTime(2019,3,14,13,0,0),new DateTime(2019,3,15,13,0,0),
                new DateTime(2019,3,18,13,0,0),new DateTime(2019,3,19,13,0,0),
                new DateTime(2019,3,20,13,0,0),new DateTime(2019,3,21,13,0,0),
                new DateTime(2019,3,22,13,0,0),new DateTime(2019,3,25,13,0,0),
                new DateTime(2019,3,26,13,0,0),new DateTime(2019,3,27,13,0,0),
                new DateTime(2019,3,28,13,0,0),new DateTime(2019,3,29,13,0,0),
                new DateTime(2019,4,1,13,0,0),new DateTime(2019,4,2,13,0,0),
                new DateTime(2019,4,3,13,0,0),new DateTime(2019,4,4,13,0,0),
                new DateTime(2019,4,5,13,0,0),new DateTime(2019,4,8,13,0,0),
                new DateTime(2019,4,9,13,0,0),new DateTime(2019,4,10,13,0,0),
                new DateTime(2019,4,11,13,0,0),new DateTime(2019,4,12,13,0,0),
                new DateTime(2019,4,15,13,0,0),
            };
        Assert.Equal(Expectedoutput, Actualoutput);
        //ByDay with interval - 2
        List<DateTime> Actualval = ActualResult(new DateTime(2019, 9, 2), "FREQ=WEEKLY;INTERVAL=2;BYDAY=SU,MO,TU,WE,TH,FR,SA;");
        List<DateTime> Expectedval = new List<DateTime>
            {
                new DateTime(2019,9,2),new DateTime(2019,9,3),
                new DateTime(2019,9,4),new DateTime(2019,9,5),
                new DateTime(2019,9,6),new DateTime(2019,9,7),
                new DateTime(2019,9,15),new DateTime(2019,9,16),
                new DateTime(2019,9,17),new DateTime(2019,9,18),
                new DateTime(2019,9,19),new DateTime(2019,9,20),
                new DateTime(2019,9,21),new DateTime(2019,9,29),
                new DateTime(2019,9,30),new DateTime(2019,10,1),
                new DateTime(2019,10,2),new DateTime(2019,10,3),
                new DateTime(2019,10,4),new DateTime(2019,10,5),
                new DateTime(2019,10,13),new DateTime(2019,10,14),
                new DateTime(2019,10,15),new DateTime(2019,10,16),
                new DateTime(2019,10,17),new DateTime(2019,10,18),
                new DateTime(2019,10,19),new DateTime(2019,10,27),
                new DateTime(2019,10,28),new DateTime(2019,10,29),
                new DateTime(2019,10,30),new DateTime(2019,10,31),
                new DateTime(2019,11,1),new DateTime(2019,11,2),
                new DateTime(2019,11,10),new DateTime(2019,11,11),
                new DateTime(2019,11,12),new DateTime(2019,11,13),
                new DateTime(2019,11,14),new DateTime(2019,11,15),
                new DateTime(2019,11,16),new DateTime(2019,11,24),
                new DateTime(2019,11,25),
            };
        Assert.Equal(Expectedval, Actualval);

        //TO CHECK RECURRENCE FREQUENCY WEEKLY WITH UNTIL

        //ByDay with interval - 1 and until
        List<DateTime> ActualVar = ActualResult(new DateTime(2019, 1, 5, 8, 0, 0), "FREQ=WEEKLY;BYDAY=SU,SA;INTERVAL=1;UNTIL=20190323T000000Z;");
        List<DateTime> ExpectedVar = new List<DateTime>
            {
            new DateTime(2019,1,5,8,0,0),new DateTime(2019,1,6,8,0,0),
            new DateTime(2019,1,12,8,0,0),new DateTime(2019,1,13,8,0,0),
            new DateTime(2019,1,19,8,0,0),new DateTime(2019,1,20,8,0,0),
            new DateTime(2019,1,26,8,0,0),new DateTime(2019,1,27,8,0,0),
            new DateTime(2019,2,2,8,0,0),new DateTime(2019,2,3,8,0,0),
            new DateTime(2019,2,9,8,0,0),new DateTime(2019,2,10,8,0,0),
            new DateTime(2019,2,16,8,0,0),new DateTime(2019,2,17,8,0,0),
            new DateTime(2019,2,23,8,0,0),new DateTime(2019,2,24,8,0,0),
            new DateTime(2019,3,2,8,0,0),new DateTime(2019,3,3,8,0,0),
            new DateTime(2019,3,9,8,0,0),new DateTime(2019,3,10,8,0,0),
            new DateTime(2019,3,16,8,0,0),new DateTime(2019,3,17,8,0,0),
            new DateTime(2019,3,23,8,0,0),
            };
        Assert.Equal(ExpectedVar, ActualVar);

        //ByDay with interval-2 and until
        List<DateTime> ActualValue = ActualResult(new DateTime(2019, 11, 1, 12, 0, 0), "FREQ=WEEKLY;BYDAY=MO,FR,SA;INTERVAL=2;UNTIL=20200204T000000Z;");
        List<DateTime> ExpectedValue = new List<DateTime>
            {
            new DateTime(2019, 11, 1, 12, 0, 0),new DateTime(2019, 11, 2, 12, 0, 0),
            new DateTime(2019, 11, 11, 12, 0, 0),new DateTime(2019, 11, 15, 12, 0, 0),
            new DateTime(2019, 11, 16, 12, 0, 0),new DateTime(2019, 11, 25, 12, 0, 0),
            new DateTime(2019, 11, 29, 12, 0, 0),new DateTime(2019, 11, 30, 12, 0, 0),
            new DateTime(2019, 12, 9, 12, 0, 0),new DateTime(2019, 12, 13, 12, 0, 0),
            new DateTime(2019, 12, 14, 12, 0, 0),new DateTime(2019, 12, 23, 12, 0, 0),
            new DateTime(2019, 12, 27, 12, 0, 0),new DateTime(2019, 12, 28, 12, 0, 0),
            new DateTime(2020, 1, 6, 12, 0, 0),new DateTime(2020, 1, 10, 12, 0, 0),
            new DateTime(2020, 1, 11, 12, 0, 0),new DateTime(2020, 1, 20, 12, 0, 0),
            new DateTime(2020, 1, 24, 12, 0, 0),new DateTime(2020, 1, 25, 12, 0, 0),
            new DateTime(2020, 2, 3, 12, 0, 0),
            };
        Assert.Equal(ExpectedValue, ActualValue);

        //ByDay with interval-3 and until
        List<DateTime> ActualVal = ActualResult(new DateTime(2019, 4, 10, 9, 0, 0), "FREQ=WEEKLY;BYDAY=TH;INTERVAL=3;UNTIL=20190730T000000Z;");
        List<DateTime> ExpectedVal = new List<DateTime>
            {
                new DateTime(2019,4,11,9,0,0),
                new DateTime(2019,5,2,9,0,0),
                new DateTime(2019,5,23,9,0,0),
                new DateTime(2019,6,13,9,0,0),
                new DateTime(2019,7,4,9,0,0),
                new DateTime(2019,7,25,9,0,0),
            };
        Assert.Equal(ExpectedVal, ActualVal);

        //ByDay with interval-1 and until
        List<DateTime> Actualres = ActualResult(new DateTime(2019, 2, 1, 12, 0, 0), "FREQ=WEEKLY;BYDAY=WE,TH,FR,MO,TU;INTERVAL=1;UNTIL=20190625T000000Z;");
        List<DateTime> Expectedres = new List<DateTime>
            {
                new DateTime(2019,2,1,12,0,0),new DateTime(2019,2,4,12,0,0),
                new DateTime(2019,2,5,12,0,0),new DateTime(2019,2,6,12,0,0),
                new DateTime(2019,2,7,12,0,0),new DateTime(2019,2,8,12,0,0),
                new DateTime(2019,2,11,12,0,0),new DateTime(2019,2,12,12,0,0),
                new DateTime(2019,2,13,12,0,0),new DateTime(2019,2,14,12,0,0),
                new DateTime(2019,2,15,12,0,0),new DateTime(2019,2,18,12,0,0),
                new DateTime(2019,2,19,12,0,0),new DateTime(2019,2,20,12,0,0),
                new DateTime(2019,2,21,12,0,0),new DateTime(2019,2,22,12,0,0),
                new DateTime(2019,2,25,12,0,0),new DateTime(2019,2,26,12,0,0),
                new DateTime(2019,2,27,12,0,0),new DateTime(2019,2,28,12,0,0),
                new DateTime(2019,3,1,12,0,0),new DateTime(2019,3,4,12,0,0),
                new DateTime(2019,3,5,12,0,0),new DateTime(2019,3,6,12,0,0),
                new DateTime(2019,3,7,12,0,0),new DateTime(2019,3,8,12,0,0),
                new DateTime(2019,3,11,12,0,0),new DateTime(2019,3,12,12,0,0),
                new DateTime(2019,3,13,12,0,0),new DateTime(2019,3,14,12,0,0),
                new DateTime(2019,3,15,12,0,0),new DateTime(2019,3,18,12,0,0),
                new DateTime(2019,3,19,12,0,0),new DateTime(2019,3,20,12,0,0),
                new DateTime(2019,3,21,12,0,0),new DateTime(2019,3,22,12,0,0),
                new DateTime(2019,3,25,12,0,0),new DateTime(2019,3,26,12,0,0),
                new DateTime(2019,3,27,12,0,0),new DateTime(2019,3,28,12,0,0),
                new DateTime(2019,3,29,12,0,0),new DateTime(2019,4,1,12,0,0),
                new DateTime(2019,4,2,12,0,0),new DateTime(2019,4,3,12,0,0),
                new DateTime(2019,4,4,12,0,0),new DateTime(2019,4,5,12,0,0),
                new DateTime(2019,4,8,12,0,0),new DateTime(2019,4,9,12,0,0),
                new DateTime(2019,4,10,12,0,0),new DateTime(2019,4,11,12,0,0),
                new DateTime(2019,4,12,12,0,0),new DateTime(2019,4,15,12,0,0),
                new DateTime(2019,4,16,12,0,0),new DateTime(2019,4,17,12,0,0),
                new DateTime(2019,4,18,12,0,0),new DateTime(2019,4,19,12,0,0),
                new DateTime(2019,4,22,12,0,0),new DateTime(2019,4,23,12,0,0),
                new DateTime(2019,4,24,12,0,0),new DateTime(2019,4,25,12,0,0),
                new DateTime(2019,4,26,12,0,0),new DateTime(2019,4,29,12,0,0),
                new DateTime(2019,4,30,12,0,0),new DateTime(2019,5,1,12,0,0),
                new DateTime(2019,5,2,12,0,0),new DateTime(2019,5,3,12,0,0),
                new DateTime(2019,5,6,12,0,0),new DateTime(2019,5,7,12,0,0),
                new DateTime(2019,5,8,12,0,0),new DateTime(2019,5,9,12,0,0),
                new DateTime(2019,5,10,12,0,0),new DateTime(2019,5,13,12,0,0),
                new DateTime(2019,5,14,12,0,0),new DateTime(2019,5,15,12,0,0),
                new DateTime(2019,5,16,12,0,0),new DateTime(2019,5,17,12,0,0),
                new DateTime(2019,5,20,12,0,0),new DateTime(2019,5,21,12,0,0),
                new DateTime(2019,5,22,12,0,0),new DateTime(2019,5,23,12,0,0),
                new DateTime(2019,5,24,12,0,0),new DateTime(2019,5,27,12,0,0),
                new DateTime(2019,5,28,12,0,0),new DateTime(2019,5,29,12,0,0),
                new DateTime(2019,5,30,12,0,0),new DateTime(2019,5,31,12,0,0),
                new DateTime(2019,6,3,12,0,0),new DateTime(2019,6,4,12,0,0),
                new DateTime(2019,6,5,12,0,0),new DateTime(2019,6,6,12,0,0),
                new DateTime(2019,6,7,12,0,0),new DateTime(2019,6,10,12,0,0),
                new DateTime(2019,6,11,12,0,0),new DateTime(2019,6,12,12,0,0),
                new DateTime(2019,6,13,12,0,0),new DateTime(2019,6,14,12,0,0),
                new DateTime(2019,6,17,12,0,0),new DateTime(2019,6,18,12,0,0),
                new DateTime(2019,6,19,12,0,0),new DateTime(2019,6,20,12,0,0),
                new DateTime(2019,6,21,12,0,0),new DateTime(2019,6,24,12,0,0),
                new DateTime(2019,6,25,12,0,0),
            };
        Assert.Equal(Expectedres, Actualres);
        //ByDay, WKST and count
        List<DateTime> ActualResultt = ActualResult(new DateTime(2019, 4, 1), "FREQ=WEEKLY;INTERVAL=2;COUNT=4;BYDAY=TU,SU;WKST=SU;");
        List<DateTime> ExpectedResult = new List<DateTime>
            {
                new DateTime(2019,4,2),new DateTime(2019,4,14),
                new DateTime(2019,4,16),new DateTime(2019,4,28),
            };
        Assert.Equal(ExpectedResult, ActualResultt);
        //ByDay, WKST and count
        List<DateTime> ActualResultts = ActualResult(new DateTime(2019, 4, 1), "FREQ=WEEKLY;INTERVAL=2;COUNT=4;BYDAY=TU,SU;WKST=MO;");
        List<DateTime> ExpectedResults = new List<DateTime>
            {
                new DateTime(2019,4,2),new DateTime(2019,4,14),
                new DateTime(2019,4,16),new DateTime(2019,4,28),
            };
        Assert.Equal(ExpectedResults, ActualResultts);
    }

    [Fact]
    public void GetMonthlyRecurrence()
    {
        //TO CHECK RECURRENCE FREQUENCY MONTHLY WITH COUNT

        //ByMonth, ByMonthDay
        //List<DateTime> ActualR = ActualResult(new DateTime(2019, 1, 6), "FREQ=MONTHLY;INTERVAL=1;COUNT=10;BYMONTHDAY=3;");
        //List<DateTime> ExpectedR = new List<DateTime>
        //    {
        //        new DateTime(2019,2,3),new DateTime(2019,3,3),new DateTime(2019,4,3),
        //        new DateTime(2019,5,3),new DateTime(2019,6,3),new DateTime(2019,7,3),
        //        new DateTime(2019,8,3),new DateTime(2019,9,3),new DateTime(2019,10,3),
        //        new DateTime(2019,11,3),
        //    };
        //Assert.Equal(ExpectedR, ActualR);

        //ByMonthDay
        //List<DateTime> ActualResulm = ActualResult(new DateTime(2019, 1, 6), "FREQ=MONTHLY;INTERVAL=1;COUNT=9;BYMONTHDAY=30;");
        //List<DateTime> ExpectedResulm = new List<DateTime>
        //    {
        //        new DateTime(2019,1,30),new DateTime(2019,3,30),new DateTime(2019,4,30),
        //        new DateTime(2019,5,30),new DateTime(2019,6,30),new DateTime(2019,7,30),
        //        new DateTime(2019,8,30),new DateTime(2019,9,30),new DateTime(2019,10,30),
        //    };
        //Assert.Equal(ExpectedResulm, ActualResulm);

        //ByMonthDay
        //List<DateTime> _ActualResult = ActualResult(new DateTime(2020, 1, 6), "FREQ=MONTHLY;INTERVAL=1;COUNT=9;BYMONTHDAY=30;");
        //List<DateTime> _ExpectedResult = new List<DateTime>
        //    {
        //        new DateTime(2020,1,30),new DateTime(2020,3,30),new DateTime(2020,4,30),
        //        new DateTime(2020,5,30),new DateTime(2020,6,30),new DateTime(2020,7,30),
        //        new DateTime(2020,8,30),new DateTime(2020,9,30),new DateTime(2020,10,30),
        //    };
        //Assert.Equal(_ExpectedResult, _ActualResult);

        //ByMonthDay 
        //List<DateTime> ActualV = ActualResult(new DateTime(2019, 5, 6), "FREQ=MONTHLY;INTERVAL=1;COUNT=5;BYMONTHDAY=31;");
        //List<DateTime> ExpectedV = new List<DateTime>
        //    {
        //        new DateTime(2019,5,31),new DateTime(2019,7,31),new DateTime(2019,8,31),
        //        new DateTime(2019,10,31),new DateTime(2019,12,31),
        //    };
        //Assert.Equal(ExpectedV, ActualV);

        //ByMonthDay
        //List<DateTime> Actual_Values = ActualResult(new DateTime(2019, 2, 1), "FREQ=MONTHLY;INTERVAL=1;COUNT=5;BYMONTHDAY=28;");
        //List<DateTime> Expected_Values = new List<DateTime>
        //    {
        //        new DateTime(2019,2,28),new DateTime(2019,3,28),new DateTime(2019,4,28),
        //        new DateTime(2019,5,28),new DateTime(2019,6,28),
        //    };
        //Assert.Equal(Expected_Values, Actual_Values);

        //ByMonthDay
        //List<DateTime> Actual_ = ActualResult(new DateTime(2019, 1, 19), "FREQ=MONTHLY;INTERVAL=1;COUNT=19;BYMONTHDAY=29;");
        //List<DateTime> Expected_ = new List<DateTime>
        //    {
        //        new DateTime(2019,1,29),new DateTime(2019,3,29),new DateTime(2019,4,29),
        //        new DateTime(2019,5,29),new DateTime(2019,6,29),new DateTime(2019,7,29),
        //        new DateTime(2019,8,29),new DateTime(2019,9,29),new DateTime(2019,10,29),
        //        new DateTime(2019,11,29),new DateTime(2019,12,29),new DateTime(2020,1,29),
        //        new DateTime(2020,2,29),new DateTime(2020,3,29),new DateTime(2020,4,29),
        //        new DateTime(2020,5,29),new DateTime(2020,6,29),new DateTime(2020,7,29),
        //        new DateTime(2020,8,29),
        //    };
        //Assert.Equal(Expected_, Actual_);

        //ByMonthDay
        //List<DateTime> ActualRes = ActualResult(new DateTime(2019, 1, 6), "FREQ=MONTHLY;INTERVAL=1;COUNT=12;BYMONTHDAY=5;");
        //List<DateTime> ExpectedRes = new List<DateTime>
        //    {
        //        new DateTime(2019,2,5),new DateTime(2019,3,5),
        //        new DateTime(2019,4,5),new DateTime(2019,5,5),
        //        new DateTime(2019,6,5),new DateTime(2019,7,5),
        //        new DateTime(2019,8,5),new DateTime(2019,9,5),
        //        new DateTime(2019,10,5),new DateTime(2019,11,5),
        //        new DateTime(2019,12,5),new DateTime(2020,1,5),
        //    };
        //Assert.Equal(ExpectedRes, ActualRes);

        //ByMonthDay 
        //List<DateTime> ActualResults = ActualResult(new DateTime(2019, 1, 6), "FREQ=MONTHLY;INTERVAL=2;COUNT=17;BYMONTHDAY=22;");
        //List<DateTime> ExpectedResult = new List<DateTime>
        //    {
        //        new DateTime(2019,1,22),new DateTime(2019,3,22),
        //        new DateTime(2019,5,22),new DateTime(2019,7,22),
        //        new DateTime(2019,9,22),new DateTime(2019,11,22),
        //        new DateTime(2020,1,22),new DateTime(2020,3,22),
        //        new DateTime(2020,5,22),new DateTime(2020,7,22),
        //        new DateTime(2020,9,22),new DateTime(2020,11,22),
        //        new DateTime(2021,1,22),new DateTime(2021,3,22),
        //        new DateTime(2021,5,22),new DateTime(2021,7,22),
        //        new DateTime(2021,9,22),
        //    };
        //Assert.Equal(ExpectedResult, ActualResults);

        //ByMonthDay 
        //List<DateTime> Actual = ActualResult(new DateTime(2019, 1, 6), "FREQ=MONTHLY;INTERVAL=4;COUNT=9;BYMONTHDAY=11;");
        //List<DateTime> Expected = new List<DateTime>
        //    {
        //        new DateTime(2019,1,11),new DateTime(2019,5,11),
        //        new DateTime(2019,9,11),new DateTime(2020,1,11),
        //        new DateTime(2020,5,11),new DateTime(2020,9,11),
        //        new DateTime(2021,1,11),new DateTime(2021,5,11),
        //        new DateTime(2021,9,11),
        //    };
        //Assert.Equal(Expected, Actual);

        //ByDay & BySetpos
        //List<DateTime> ActualResulval = ActualResult(new DateTime(2019, 2, 6), "FREQ=MONTHLY;INTERVAL=1;COUNT=15;BYDAY=MO;BYSETPOS=-1;");
        //List<DateTime> ExpectedResults = new List<DateTime>
        //    {
        //        new DateTime(2019,2,25),new DateTime(2019,3,25),
        //        new DateTime(2019,4,29),new DateTime(2019,5,27),
        //        new DateTime(2019,6,24),new DateTime(2019,7,29),
        //        new DateTime(2019,8,26),new DateTime(2019,9,30),
        //        new DateTime(2019,10,28),new DateTime(2019,11,25),
        //        new DateTime(2019,12,30),new DateTime(2020,1,27),
        //        new DateTime(2020,2,24),new DateTime(2020,3,30),
        //        new DateTime(2020,4,27),
        //    };
        //Assert.Equal(ExpectedResults, ActualResulval);
        //ByDay & BySetpos

        List<DateTime> Actualv = ActualResult(new DateTime(2019, 10, 1), "FREQ=MONTHLY;INTERVAL=2;COUNT=24;BYDAY=SU;BYSETPOS=2;");
        List<DateTime> Expectedv = new List<DateTime>
            {
                new DateTime(2019,10,13),new DateTime(2019,12,8),
                new DateTime(2020,2,9),new DateTime(2020,4,12),
                new DateTime(2020,6,14),new DateTime(2020,8,9),
                new DateTime(2020,10,11),new DateTime(2020,12,13),
                new DateTime(2021,2,14),new DateTime(2021,4,11),
                new DateTime(2021,6,13),new DateTime(2021,8,8),
                new DateTime(2021,10,10),new DateTime(2021,12,12),
                new DateTime(2022,2,13),new DateTime(2022,4,10),
                new DateTime(2022,6,12),new DateTime(2022,8,14),
                new DateTime(2022,10,9),new DateTime(2022,12,11),
                new DateTime(2023,2,12),new DateTime(2023,4,9),
                new DateTime(2023,6,11),new DateTime(2023,8,13),
            };
        Assert.Equal(Expectedv, Actualv);


        //TO CHECK RECURRENCE FREQUENCY MONTHLY WITH UNTIL

        //ByMonthDay
        List<DateTime> Actual_Value = ActualResult(new DateTime(2019, 1, 27), "FREQ=MONTHLY;INTERVAL=1;UNTIL=20200131T000000Z;BYMONTHDAY=30;");
        List<DateTime> Expected_Value = new List<DateTime>
            {
                new DateTime(2019,1,30),new DateTime(2019,3,30),new DateTime(2019,4,30),
                new DateTime(2019,5,30),new DateTime(2019,6,30),new DateTime(2019,7,30),
                new DateTime(2019,8,30),new DateTime(2019,9,30),new DateTime(2019,10,30),
                new DateTime(2019,11,30),new DateTime(2019,12,30),new DateTime(2020,1,30),
            };
        Assert.Equal(Expected_Value, Actual_Value);

        //ByMonthDay
        List<DateTime> _Actualval = ActualResult(new DateTime(2020, 1, 6), "FREQ=MONTHLY;INTERVAL=1;UNTIL=20210131T000000Z;BYMONTHDAY=30;");
        List<DateTime> _Expectedval = new List<DateTime>
            {
                new DateTime(2020,1,30),new DateTime(2020,3,30),new DateTime(2020,4,30),
                new DateTime(2020,5,30),new DateTime(2020,6,30),new DateTime(2020,7,30),
                new DateTime(2020,8,30),new DateTime(2020,9,30),new DateTime(2020,10,30),
                new DateTime(2020,11,30),new DateTime(2020,12,30),new DateTime(2021,1,30),
            };
        Assert.Equal(_Expectedval, _Actualval);

        //ByMonthDay -------
        //List<DateTime> ActualVar = ActualResult(new DateTime(2019, 1, 6), "FREQ=MONTHLY;INTERVAL=1;UNTIL=20210123T091658Z;BYMONTHDAY=31;");
        //List<DateTime> ExpectedVar = new List<DateTime>
        //    {
        //        new DateTime(2019,1,31),new DateTime(2019,3,31),new DateTime(2019,5,31),
        //        new DateTime(2019,7,31),new DateTime(2019,8,31),new DateTime(2019,10,31),
        //        new DateTime(2019,12,31),new DateTime(2020,1,31),new DateTime(2020,3,31),
        //        new DateTime(2020,5,31),new DateTime(2020,7,31),new DateTime(2020,8,31),
        //        new DateTime(2020,10,31),new DateTime(2020,12,31),
        //    };
        //Assert.Equal(ExpectedVar, ActualVar);

        //ByMonthDay
        List<DateTime> Actual_vals = ActualResult(new DateTime(2019, 1, 10), "FREQ=MONTHLY;INTERVAL=1;UNTIL=20200323T000000Z;BYMONTHDAY=28;");
        List<DateTime> Expected_vals = new List<DateTime>
            {
                new DateTime(2019,1,28),new DateTime(2019,2,28),new DateTime(2019,3,28),
                new DateTime(2019,4,28),new DateTime(2019,5,28),new DateTime(2019,6,28),
                new DateTime(2019,7,28),new DateTime(2019,8,28),new DateTime(2019,9,28),
                new DateTime(2019,10,28),new DateTime(2019,11,28),new DateTime(2019,12,28),
                new DateTime(2020,1,28),new DateTime(2020,2,28),
            };
        Assert.Equal(Expected_vals, Actual_vals);

        //ByMonthDay -------------
        //List<DateTime> Actual_outputs = ActualResult(new DateTime(2019, 1, 1), "FREQ=MONTHLY;INTERVAL=1;UNTIL=20200823T000000Z;BYMONTHDAY=29;");
        //List<DateTime> Expected_outputs = new List<DateTime>
        //    {
        //        new DateTime(2019,1,29),new DateTime(2019,3,29),new DateTime(2019,4,29),
        //        new DateTime(2019,5,29),new DateTime(2019,6,29),new DateTime(2019,7,29),
        //        new DateTime(2019,8,29),new DateTime(2019,9,29),new DateTime(2019,10,29),
        //        new DateTime(2019,11,29),new DateTime(2019,12,29),new DateTime(2020,1,29),
        //        new DateTime(2020,2,29),new DateTime(2020,3,29),new DateTime(2020,4,29),
        //        new DateTime(2020,5,29),new DateTime(2020,6,29),new DateTime(2020,7,29),

        //    };
        //Assert.Equal(Expected_outputs, Actual_outputs);

        //ByMonth, ByDay, BySetPOS
        List<DateTime> ActualVal = ActualResult(new DateTime(2019, 1, 27), "FREQ=MONTHLY;INTERVAL=2;UNTIL=20190724T000000Z;BYDAY=WE;BYSETPOS=2;");
        List<DateTime> ExpectedVal = new List<DateTime>
            {
                new DateTime(2019,2,13),new DateTime(2019,4,10),new DateTime(2019,6,12),
            };
        Assert.Equal(ExpectedVal, ActualVal);

        //ByMonth, ByDay, BySetPOS
        List<DateTime> ActualValue = ActualResult(new DateTime(2019, 4, 2), "FREQ=MONTHLY;INTERVAL=3;UNTIL=20200401T000000Z;BYDAY=SA;BYSETPOS=4;");
        List<DateTime> ExpectedValue = new List<DateTime>
            {
                new DateTime(2019,4,27),new DateTime(2019,7,27),
                new DateTime(2019,10,26),new DateTime(2020,1,25),
            };
        Assert.Equal(ExpectedValue, ActualValue);

        //ByMonth, ByDay & BySetPos
        List<DateTime> ActualValues = ActualResult(new DateTime(2019, 12, 4), "FREQ=MONTHLY;INTERVAL=1;UNTIL=20201117T000000Z;BYDAY=TH;BYSETPOS=3;");
        List<DateTime> ExpectedValues = new List<DateTime>
            {
                new DateTime(2019,12,19),new DateTime(2020,1,16),
                new DateTime(2020,2,20),new DateTime(2020,3,19),
                new DateTime(2020,4,16),new DateTime(2020,5,21),
                new DateTime(2020,6,18),new DateTime(2020,7,16),
                new DateTime(2020,8,20),new DateTime(2020,9,17),
                new DateTime(2020,10,15),
            };
        Assert.Equal(ExpectedValues, ActualValues);

        //Byday & BySetpos
        List<DateTime> Actualval = ActualResult(new DateTime(2019, 10, 1), "FREQ=MONTHLY;BYDAY=FR;BYSETPOS=2;INTERVAL=1;UNTIL=20200711T000000Z;");
        List<DateTime> Expectedval = new List<DateTime>
            {
                new DateTime(2019,10,11),new DateTime(2019,11,8),
                new DateTime(2019,12,13),new DateTime(2020,1,10),
                new DateTime(2020,2,14),new DateTime(2020,3,13),
                new DateTime(2020,4,10),new DateTime(2020,5,8),
                new DateTime(2020,6,12),new DateTime(2020,7,10),
            };
        Assert.Equal(Expectedval, Actualval);

        //TO CHECK RECURRENCE FREQUENCY MONTHLY WITH NEVER

        //ByMonthDay --------
        //List<DateTime> Actual_results = ActualResult(new DateTime(2019, 1, 4), "FREQ=MONTHLY;INTERVAL=1;BYMONTHDAY=30;");
        //List<DateTime> Expected_results = new List<DateTime>
        //    {
        //        new DateTime(2019,1,30),new DateTime(2019,3,30),new DateTime(2019,4,30),
        //        new DateTime(2019,5,30),new DateTime(2019,6,30),new DateTime(2019,7,30),
        //        new DateTime(2019,8,30),new DateTime(2019,9,30),new DateTime(2019,10,30),
        //        new DateTime(2019,11,30),new DateTime(2019,12,30),new DateTime(2020,1,30),
        //        new DateTime(2020,3,30),new DateTime(2020,4,30),new DateTime(2020,5,30),
        //        new DateTime(2020,6,30),new DateTime(2020,7,30),new DateTime(2020,8,30),
        //        new DateTime(2020,9,30),new DateTime(2020,10,30),new DateTime(2020,11,30),
        //        new DateTime(2020,12,30),new DateTime(2021,1,30),new DateTime(2021,3,30),
        //        new DateTime(2021,4,30),new DateTime(2021,5,30),new DateTime(2021,6,30),
        //        new DateTime(2021,7,30),new DateTime(2021,8,30),new DateTime(2021,9,30),
        //        new DateTime(2021,10,30),new DateTime(2021,11,30),new DateTime(2021,12,30),
        //        new DateTime(2022,1,30),new DateTime(2022,3,30),new DateTime(2022,4,30),
        //        new DateTime(2022,5,30),new DateTime(2022,6,30),new DateTime(2022,7,30),
        //        new DateTime(2022,8,30),new DateTime(2022,9,30),new DateTime(2022,10,30),
        //        new DateTime(2022,11,30),
        //    };
        //Assert.Equal(Expected_results, Actual_results);

        //ByMonthDay
        List<DateTime> _ActualVar = ActualResult(new DateTime(2019, 2, 1), "FREQ=MONTHLY;INTERVAL=1;BYMONTHDAY=28;");
        List<DateTime> _ExpectedVar = new List<DateTime>
            {
                new DateTime(2019,2,28),new DateTime(2019,3,28),new DateTime(2019,4,28),
                new DateTime(2019,5,28),new DateTime(2019,6,28),new DateTime(2019,7,28),
                new DateTime(2019,8,28),new DateTime(2019,9,28),new DateTime(2019,10,28),
                new DateTime(2019,11,28),new DateTime(2019,12,28),new DateTime(2020,1,28),
                new DateTime(2020,2,28),new DateTime(2020,3,28),new DateTime(2020,4,28),
                new DateTime(2020,5,28),new DateTime(2020,6,28),new DateTime(2020,7,28),
                new DateTime(2020,8,28),new DateTime(2020,9,28),new DateTime(2020,10,28),
                new DateTime(2020,11,28),new DateTime(2020,12,28),new DateTime(2021,1,28),
                new DateTime(2021,2,28),new DateTime(2021,3,28),new DateTime(2021,4,28),
                new DateTime(2021,5,28),new DateTime(2021,6,28),new DateTime(2021,7,28),
                new DateTime(2021,8,28),new DateTime(2021,9,28),new DateTime(2021,10,28),
                new DateTime(2021,11,28),new DateTime(2021,12,28),new DateTime(2022,1,28),
                new DateTime(2022,2,28),new DateTime(2022,3,28),new DateTime(2022,4,28),
                new DateTime(2022,5,28),new DateTime(2022,6,28),new DateTime(2022,7,28),
                new DateTime(2022,8,28),
            };
        Assert.Equal(_ExpectedVar, _ActualVar);

        ////ByMonth ---------
        //List<DateTime> Actual_Result = ActualResult(new DateTime(2019, 1, 4), "FREQ=MONTHLY;INTERVAL=1;BYMONTHDAY=29;");
        //List<DateTime> Expected_Result = new List<DateTime>
        //    {
        //        new DateTime(2019,1,29),new DateTime(2019,3,29),new DateTime(2019,4,29),
        //        new DateTime(2019,5,29),new DateTime(2019,6,29),new DateTime(2019,7,29),
        //        new DateTime(2019,8,29),new DateTime(2019,9,29),new DateTime(2019,10,29),
        //        new DateTime(2019,11,29),new DateTime(2019,12,29),new DateTime(2020,1,29),
        //        new DateTime(2020,2,29),new DateTime(2020,3,29),new DateTime(2020,4,29),
        //        new DateTime(2020,5,29),new DateTime(2020,6,29),new DateTime(2020,7,29),
        //        new DateTime(2020,8,29),new DateTime(2020,9,29),new DateTime(2020,10,29),
        //        new DateTime(2020,11,29),new DateTime(2020,12,29),new DateTime(2021,1,29),
        //        new DateTime(2021,3,29),new DateTime(2021,4,29),new DateTime(2021,5,29),
        //        new DateTime(2021,6,29),new DateTime(2021,7,29),new DateTime(2021,8,29),
        //        new DateTime(2021,9,29),new DateTime(2021,10,29),new DateTime(2021,11,29),
        //        new DateTime(2021,12,29),new DateTime(2022,1,29),new DateTime(2022,3,29),
        //        new DateTime(2022,4,29),new DateTime(2022,5,29),new DateTime(2022,6,29),
        //        new DateTime(2022,7,29),new DateTime(2022,8,29),new DateTime(2022,9,29),
        //        new DateTime(2022,10,29),
        //    };
        //Assert.Equal(Expected_Result, Actual_Result);

        ////ByMonth   -----------
        //List<DateTime> Actual_Results = ActualResult(new DateTime(2019, 5, 2), "FREQ=MONTHLY;INTERVAL=1;BYMONTHDAY=29;");
        //List<DateTime> Expected_Results = new List<DateTime>
        //    {
        //        new DateTime(2019,5,29),new DateTime(2019,6,29),new DateTime(2019,7,29),
        //        new DateTime(2019,8,29),new DateTime(2019,9,29),new DateTime(2019,10,29),
        //        new DateTime(2019,11,29),new DateTime(2019,12,29),new DateTime(2020,1,29),
        //        new DateTime(2020,2,29),new DateTime(2020,3,29),new DateTime(2020,4,29),
        //        new DateTime(2020,5,29),new DateTime(2020,6,29),new DateTime(2020,7,29),
        //        new DateTime(2020,8,29),new DateTime(2020,9,29),new DateTime(2020,10,29),
        //        new DateTime(2020,11,29),new DateTime(2020,12,29),new DateTime(2021,1,29),
        //        new DateTime(2021,3,29),new DateTime(2021,4,29),new DateTime(2021,5,29),
        //        new DateTime(2021,6,29),new DateTime(2021,7,29),new DateTime(2021,8,29),
        //        new DateTime(2021,9,29),new DateTime(2021,10,29),new DateTime(2021,11,29),
        //        new DateTime(2021,12,29),new DateTime(2022,1,29),new DateTime(2022,3,29),
        //        new DateTime(2022,4,29),new DateTime(2022,5,29),new DateTime(2022,6,29),
        //        new DateTime(2022,7,29),new DateTime(2022,8,29),new DateTime(2022,9,29),
        //        new DateTime(2022,10,29),new DateTime(2022,11,29),new DateTime(2022,12,29),
        //        new DateTime(2023,1,29),
        //    };
        //Assert.Equal(Expected_Results, Actual_Results);

        ////ByMonthDay outof bound
        //List<DateTime> ActualVariable = ActualResult(new DateTime(2019, 1, 6), "FREQ=MONTHLY;INTERVAL=1;BYMONTHDAY=31;");
        //List<DateTime> ExpectedVariable = new List<DateTime>
        //    {
        //        new DateTime(2019,1,31),new DateTime(2019,3,31),new DateTime(2019,5,31),
        //        new DateTime(2019,7,31),new DateTime(2019,8,31),new DateTime(2019,10,31),
        //        new DateTime(2019,12,31),new DateTime(2020,1,31),new DateTime(2020,3,31),
        //        new DateTime(2020,5,31),new DateTime(2020,7,31),new DateTime(2020,8,31),
        //        new DateTime(2020,10,31),new DateTime(2020,12,31),new DateTime(2021,1,31),
        //        new DateTime(2021,3,31),new DateTime(2021,5,31),new DateTime(2021,7,31),
        //        new DateTime(2021,8,31),new DateTime(2021,10,31),new DateTime(2021,12,31),
        //        new DateTime(2022,1,31),new DateTime(2022,3,31),new DateTime(2022,5,31),
        //        new DateTime(2022,7,31),new DateTime(2022,8,31),new DateTime(2022,10,31),
        //        new DateTime(2022,12,31),new DateTime(2023,1,31),new DateTime(2023,3,31),
        //        new DateTime(2023,5,31),new DateTime(2023,7,31),new DateTime(2023,8,31),
        //        new DateTime(2023,10,31),new DateTime(2023,12,31),new DateTime(2024,1,31),
        //        new DateTime(2024,3,31),new DateTime(2024,5,31),new DateTime(2024,7,31),
        //        new DateTime(2024,8,31),new DateTime(2024,10,31),new DateTime(2024,12,31),
        //        new DateTime(2025,1,31),

        //    };
        //Assert.Equal(ExpectedVariable, ActualVariable);
    }

    [Fact]
    public void GetYearlyRecurrence()
    {
        //TO CHECK RECURRENCE FREQUENCY YEARLY WITH COUNT

        //ByMonth & ByMonthDay
        List<DateTime> ActualR = ActualResult(new DateTime(2020, 2, 6), "FREQ=YEARLY;INTERVAL=4;COUNT=10;BYMONTHDAY=29;BYMONTH=2;");
        List<DateTime> ExpectedR = new List<DateTime>
            {
                new DateTime(2020,2,29),new DateTime(2024,2,29),new DateTime(2028,2,29),
                new DateTime(2032,2,29),new DateTime(2036,2,29),new DateTime(2040,2,29),
                new DateTime(2044,2,29),new DateTime(2048,2,29),new DateTime(2052,2,29),
                new DateTime(2056,2,29),
            };
        Assert.Equal(ExpectedR, ActualR);

        ////ByMonth & ByMonthDay   ---------
        //List<DateTime> Actual_Results = ActualResult(new DateTime(2020, 2, 6), "FREQ=YEARLY;INTERVAL=8;COUNT=50;BYMONTHDAY=29;BYMONTH=2;");
        //List<DateTime> Expected_Results = new List<DateTime>
        //    {
        //        new DateTime(2020,2,29),new DateTime(2028,2,29),new DateTime(2036,2,29),
        //        new DateTime(2044,2,29),new DateTime(2052,2,29),new DateTime(2060,2,29),
        //        new DateTime(2068,2,29),new DateTime(2076,2,29),new DateTime(2084,2,29),
        //        new DateTime(2092,2,29),new DateTime(2108,2,29),new DateTime(2116,2,29),
        //        new DateTime(2124,2,29),new DateTime(2132,2,29),new DateTime(2140,2,29),
        //        new DateTime(2148,2,29),new DateTime(2156,2,29),new DateTime(2164,2,29),
        //        new DateTime(2172,2,29),new DateTime(2180,2,29),new DateTime(2188,2,29),
        //        new DateTime(2196,2,29),new DateTime(2204,2,29),new DateTime(2212,2,29),
        //        new DateTime(2220,2,29),new DateTime(2228,2,29),new DateTime(2236,2,29),
        //        new DateTime(2244,2,29),new DateTime(2252,2,29),new DateTime(2260,2,29),
        //        new DateTime(2268,2,29),new DateTime(2276,2,29),new DateTime(2284,2,29),
        //        new DateTime(2292,2,29),new DateTime(2308,2,29),new DateTime(2316,2,29),
        //        new DateTime(2324,2,29),new DateTime(2332,2,29),new DateTime(2340,2,29),
        //        new DateTime(2348,2,29),new DateTime(2356,2,29),new DateTime(2364,2,29),
        //        new DateTime(2372,2,29),new DateTime(2380,2,29),new DateTime(2388,2,29),
        //        new DateTime(2396,2,29),new DateTime(2404,2,29),new DateTime(2412,2,29),
        //        new DateTime(2420,2,29),new DateTime(2428,2,29),

        //    };
        //Assert.Equal(Expected_Results, Actual_Results);

        //ByMonth & ByMonthDay
        List<DateTime> actual_ = ActualResult(new DateTime(2020, 1, 6), "FREQ=YEARLY;INTERVAL=1;COUNT=9;BYMONTHDAY=30;BYMONTH=1;");
        List<DateTime> expected_ = new List<DateTime>
            {
               new DateTime(2020,1,30),new DateTime(2021,1,30),new DateTime(2022,1,30),
               new DateTime(2023,1,30),new DateTime(2024,1,30),new DateTime(2025,1,30),
               new DateTime(2026,1,30),new DateTime(2027,1,30),new DateTime(2028,1,30),
            };
        Assert.Equal(expected_, actual_);

        ////ByMonth & ByMonthDay  ------ feb
        //List<DateTime> Actual_res = ActualResult(new DateTime(2020, 1, 19), "FREQ=YEARLY;INTERVAL=1;COUNT=9;BYMONTHDAY=29;BYMONTH=2;");
        //List<DateTime> Expected_res = new List<DateTime>
        //    {
        //        new DateTime(2020,2,29),new DateTime(2024,2,29),new DateTime(2028,2,29),
        //        new DateTime(2032,2,29),new DateTime(2036,2,29),new DateTime(2040,2,29),
        //        new DateTime(2044,2,29),new DateTime(2048,2,29),new DateTime(2052,2,29),
        //    };
        //Assert.Equal(Expected_res, Actual_res);

        ////ByMonth & ByMonthDay
        List<DateTime> Actual_result = ActualResult(new DateTime(2020, 1, 19), "FREQ=YEARLY;INTERVAL=1;COUNT=9;BYMONTHDAY=29;BYMONTH=1;");
        List<DateTime> Expected_result = new List<DateTime>
            {
                new DateTime(2020,1,29),new DateTime(2021,1,29),new DateTime(2022,1,29),
                new DateTime(2023,1,29),new DateTime(2024,1,29),new DateTime(2025,1,29),
                new DateTime(2026,1,29),new DateTime(2027,1,29),new DateTime(2028,1,29),
            };
        Assert.Equal(Expected_result, Actual_result);

        ////ByMonth & ByMonthDay
        List<DateTime> ActualResults = ActualResult(new DateTime(2019, 6, 3), "FREQ=YEARLY;INTERVAL=2;COUNT=9;BYMONTHDAY=20;BYMONTH=8;");
        List<DateTime> ExpectedResults = new List<DateTime>
            {
                new DateTime(2019,8,20),new DateTime(2021,8,20),new DateTime(2023,8,20),
                new DateTime(2025,8,20),new DateTime(2027,8,20),new DateTime(2029,8,20),
                new DateTime(2031,8,20),new DateTime(2033,8,20),new DateTime(2035,8,20),
            };
        Assert.Equal(ExpectedResults, ActualResults);

        ////ByMonth & ByMonthDay
        List<DateTime> Actual_Result = ActualResult(new DateTime(2019, 2, 3), "FREQ=YEARLY;INTERVAL=1;COUNT=19;BYMONTHDAY=28;BYMONTH=8;");
        List<DateTime> Expected_Result = new List<DateTime>
            {
                new DateTime(2019,8,28),new DateTime(2020,8,28),new DateTime(2021,8,28),
                new DateTime(2022,8,28),new DateTime(2023,8,28),new DateTime(2024,8,28),
                new DateTime(2025,8,28),new DateTime(2026,8,28),new DateTime(2027,8,28),
                new DateTime(2028,8,28),new DateTime(2029,8,28),new DateTime(2030,8,28),
                new DateTime(2031,8,28),new DateTime(2032,8,28),new DateTime(2033,8,28),
                new DateTime(2034,8,28),new DateTime(2035,8,28),new DateTime(2036,8,28),
                new DateTime(2037,8,28),
            };
        Assert.Equal(Expected_Result, Actual_Result);

        ////ByMonth & ByMonthDay
        List<DateTime> Actualval = ActualResult(new DateTime(2019, 1, 1), "FREQ=YEARLY;INTERVAL=1;COUNT=19;BYMONTHDAY=20;BYMONTH=5;");
        List<DateTime> Expectedval = new List<DateTime>
            {
                new DateTime(2019,5,20),new DateTime(2020,5,20),new DateTime(2021,5,20),
                new DateTime(2022,5,20),new DateTime(2023,5,20),new DateTime(2024,5,20),
                new DateTime(2025,5,20),new DateTime(2026,5,20),new DateTime(2027,5,20),
                new DateTime(2028,5,20),new DateTime(2029,5,20),new DateTime(2030,5,20),
                new DateTime(2031,5,20),new DateTime(2032,5,20),new DateTime(2033,5,20),
                new DateTime(2034,5,20),new DateTime(2035,5,20),new DateTime(2036,5,20),
                new DateTime(2037,5,20),
            };
        Assert.Equal(Expectedval, Actualval);

        ////ByMonth & ByMonthDay
        List<DateTime> Actualvalue = ActualResult(new DateTime(2019, 8, 16), "FREQ=YEARLY;INTERVAL=2;COUNT=12;BYMONTHDAY=25;BYMONTH=12;");
        List<DateTime> Expectedvalue = new List<DateTime>
            {
                new DateTime(2019,12,25),new DateTime(2021,12,25),new DateTime(2023,12,25),
                new DateTime(2025,12,25),new DateTime(2027,12,25),new DateTime(2029,12,25),
                new DateTime(2031,12,25),new DateTime(2033,12,25),new DateTime(2035,12,25),
                new DateTime(2037,12,25),new DateTime(2039,12,25),new DateTime(2041,12,25),
            };
        Assert.Equal(Expectedvalue, Actualvalue);

        ////ByMonth, ByDay & Bysetpos
        List<DateTime> Actual_value = ActualResult(new DateTime(2019, 5, 5), "FREQ=YEARLY;INTERVAL=1;COUNT=8;BYDAY=MO;BYMONTH=5;BYSETPOS=3;");
        List<DateTime> Expected_value = new List<DateTime>
            {
                new DateTime(2019,5,20),new DateTime(2020,5,18),new DateTime(2021,5,17),
                new DateTime(2022,5,16),new DateTime(2023,5,15),new DateTime(2024,5,20),
                new DateTime(2025,5,19),new DateTime(2026,5,18),
            };
        Assert.Equal(Expected_value, Actual_value);

        ////ByMonth, ByDay & Bysetpos infinite
        //List<DateTime> Actual_results = ActualResult(new DateTime(2019, 1, 1), "FREQ=YEARLY;INTERVAL=1;COUNT=8;BYDAY=FR;BYSETPOS=-1;BYMONTH=2;");
        //List<DateTime> Expected_results = new List<DateTime>
        //    {
        //        new DateTime(2019,2,22),new DateTime(2020,2,28),new DateTime(2021,2,26),
        //        new DateTime(2022,2,25),new DateTime(2023,2,24),new DateTime(2024,2,23),
        //        new DateTime(2025,2,28),new DateTime(2026,2,27),
        //    };
        //Assert.Equal(Expected_results, Actual_results);

        ////ByMonth, ByDay & Bysetpos
        List<DateTime> Actual_values = ActualResult(new DateTime(2019, 5, 5), "FREQ=YEARLY;INTERVAL=1;COUNT=8;BYDAY=MO;BYMONTH=5;BYSETPOS=3;");
        List<DateTime> Expected_values = new List<DateTime>
            {
                new DateTime(2019,5,20),new DateTime(2020,5,18),new DateTime(2021,5,17),
                new DateTime(2022,5,16),new DateTime(2023,5,15),new DateTime(2024,5,20),
                new DateTime(2025,5,19),new DateTime(2026,5,18),
            };
        Assert.Equal(Expected_values, Actual_values);

        //ByMonth, ByDay & Bysetpos
        List<DateTime> Actual_V = ActualResult(new DateTime(2019, 2, 5), "FREQ=YEARLY;INTERVAL=2;COUNT=21;BYDAY=TU;BYMONTH=2;BYSETPOS=1;");
        List<DateTime> Expected_V = new List<DateTime>
            {
                new DateTime(2019,2,5),new DateTime(2021,2,2),new DateTime(2023,2,7),
                new DateTime(2025,2,4),new DateTime(2027,2,2),new DateTime(2029,2,6),
                new DateTime(2031,2,4),new DateTime(2033,2,1),new DateTime(2035,2,6),
                new DateTime(2037,2,3),new DateTime(2039,2,1),new DateTime(2041,2,5),
                new DateTime(2043,2,3),new DateTime(2045,2,7),new DateTime(2047,2,5),
                new DateTime(2049,2,2),new DateTime(2051,2,7),new DateTime(2053,2,4),
                new DateTime(2055,2,2),new DateTime(2057,2,6),new DateTime(2059,2,4),
            };
        Assert.Equal(Expected_V, Actual_V);

        //ByMonth, ByDay & Bysetpos
        List<DateTime> Actual_val = ActualResult(new DateTime(2019, 11, 2), "FREQ=YEARLY;INTERVAL=1;COUNT=24;BYDAY=SU;BYMONTH=11;BYSETPOS=-1;");
        List<DateTime> Expected_val = new List<DateTime>
            {
                new DateTime(2019,11,24),new DateTime(2020,11,29),new DateTime(2021,11,28),
                new DateTime(2022,11,27),new DateTime(2023,11,26),new DateTime(2024,11,24),
                new DateTime(2025,11,30),new DateTime(2026,11,29),new DateTime(2027,11,28),
                new DateTime(2028,11,26),new DateTime(2029,11,25),new DateTime(2030,11,24),
                new DateTime(2031,11,30),new DateTime(2032,11,28),new DateTime(2033,11,27),
                new DateTime(2034,11,26),new DateTime(2035,11,25),new DateTime(2036,11,30),
                new DateTime(2037,11,29),new DateTime(2038,11,28),new DateTime(2039,11,27),
                new DateTime(2040,11,25),new DateTime(2041,11,24),new DateTime(2042,11,30),
            };
        Assert.Equal(Expected_val, Actual_val);

        //ByMonth, ByDay & Bysetpos
        List<DateTime> Actualoutput = ActualResult(new DateTime(2019, 6, 1), "FREQ=YEARLY;INTERVAL=1;COUNT=18;BYDAY=SU;BYMONTH=7;BYSETPOS=-1;");
        List<DateTime> Expectedoutput = new List<DateTime>
            {
                new DateTime(2019,7,28),new DateTime(2020,7,26),new DateTime(2021,7,25),
                new DateTime(2022,7,31),new DateTime(2023,7,30),new DateTime(2024,7,28),
                new DateTime(2025,7,27),new DateTime(2026,7,26),new DateTime(2027,7,25),
                new DateTime(2028,7,30),new DateTime(2029,7,29),new DateTime(2030,7,28),
                new DateTime(2031,7,27),new DateTime(2032,7,25),new DateTime(2033,7,31),
                new DateTime(2034,7,30),new DateTime(2035,7,29),new DateTime(2036,7,27),
            };
        Assert.Equal(Expectedoutput, Actualoutput);

        //ByMonth, ByDay & Bysetpos
        List<DateTime> ActualOutput = ActualResult(new DateTime(2019, 12, 12), "FREQ=YEARLY;INTERVAL=1;COUNT=7;BYDAY=WE;BYMONTH=4;BYSETPOS=2;");
        List<DateTime> ExpectedOutput = new List<DateTime>
            {
                new DateTime(2020,4,8),new DateTime(2021,4,14),new DateTime(2022,4,13),
                new DateTime(2023,4,12),new DateTime(2024,4,10),new DateTime(2025,4,9),
                new DateTime(2026,4,8),
            };
        Assert.Equal(ExpectedOutput, ActualOutput);

        ////TO CHECK RECURRENCE FREQUENCY YEARLY WITH UNTIL

        //ByMonth, ByDay & Bysetpos
        List<DateTime> Actual_Res = ActualResult(new DateTime(2019, 1, 10), "FREQ=YEARLY;INTERVAL=1;UNTIL=20290529T025415Z;BYDAY=TU;BYMONTH=1;BYSETPOS=3;");
        List<DateTime> Expected_Res = new List<DateTime>
            {
                new DateTime(2019,1,15),new DateTime(2020,1,21),new DateTime(2021,1,19),
                new DateTime(2022,1,18),new DateTime(2023,1,17),new DateTime(2024,1,16),
                new DateTime(2025,1,21),new DateTime(2026,1,20),new DateTime(2027,1,19),
                new DateTime(2028,1,18),new DateTime(2029,1,16),
            };
        Assert.Equal(Expected_Res, Actual_Res);

        //ByMonth, ByDay & Bysetpos
        List<DateTime> ActualValue = ActualResult(new DateTime(2019, 2, 1), "FREQ=YEARLY;INTERVAL=1;UNTIL=20300303T000000Z;BYDAY=MO;BYMONTH=2;BYSETPOS=3;");
        List<DateTime> ExpectedValue = new List<DateTime>
            {
                new DateTime(2019,2,18),new DateTime(2020,2,17),new DateTime(2021,2,15),
                new DateTime(2022,2,21),new DateTime(2023,2,20),new DateTime(2024,2,19),
                new DateTime(2025,2,17),new DateTime(2026,2,16),new DateTime(2027,2,15),
                new DateTime(2028,2,21),new DateTime(2029,2,19),new DateTime(2030,2,18),
            };
        Assert.Equal(ExpectedValue, ActualValue);

        //ByMonth, ByDay & Bysetpos
        List<DateTime> Actual_Value = ActualResult(new DateTime(2019, 5, 1), "FREQ=YEARLY;INTERVAL=1;UNTIL=20250303T000000Z;BYDAY=FR;BYMONTH=5;BYSETPOS=1;");
        List<DateTime> Expected_Value = new List<DateTime>
            {
                new DateTime(2019,5,3),new DateTime(2020,5,1),new DateTime(2021,5,7),
                new DateTime(2022,5,6),new DateTime(2023,5,5),new DateTime(2024,5,3),
            };
        Assert.Equal(Expected_Value, Actual_Value);

        ////ByMonth, ByDay & Bysetpos infinite
        //List<DateTime> Actual_Values = ActualResult(new DateTime(2019, 1, 16), "FREQ=YEARLY;INTERVAL=1;COUNT=9;BYDAY=WE;BYSETPOS=-1;BYMONTH=2;");
        //List<DateTime> Expected_Values = new List<DateTime>
        //    {
        //       new DateTime(2019,2,27),new DateTime(2020,2,26),new DateTime(2021,2,24),
        //       new DateTime(2022,2,23),new DateTime(2023,2,22),new DateTime(2024,2,28),
        //       new DateTime(2025,2,26),new DateTime(2026,2,25),new DateTime(2027,2,24),
        //    };
        //Assert.Equal(Expected_Values, Actual_Values);

        //ByMonth, ByDay & Bysetpos
        List<DateTime> Actual_R = ActualResult(new DateTime(2019, 1, 1), "FREQ=YEARLY;INTERVAL=2;UNTIL=20290529T025415Z;BYDAY=TU;BYMONTH=1;BYSETPOS=3;");
        List<DateTime> Expected_R = new List<DateTime>
            {
                new DateTime(2019,1,15),new DateTime(2021,1,19),new DateTime(2023,1,17),
                new DateTime(2025,1,21),new DateTime(2027,1,19),new DateTime(2029,1,16),
            };
        Assert.Equal(Expected_R, Actual_R);

        //ByMonth & ByMonthDay
        List<DateTime> Actual = ActualResult(new DateTime(2019, 6, 3), "FREQ=YEARLY;INTERVAL=1;UNTIL=20300716T000000Z;BYMONTHDAY=14;BYMONTH=3;");
        List<DateTime> Expected = new List<DateTime>
            {
                new DateTime(2020,3,14),new DateTime(2021,3,14),new DateTime(2022,3,14),
                new DateTime(2023,3,14),new DateTime(2024,3,14),new DateTime(2025,3,14),
                new DateTime(2026,3,14),new DateTime(2027,3,14),new DateTime(2028,3,14),
                new DateTime(2029,3,14),new DateTime(2030,3,14),
            };
        Assert.Equal(Expected, Actual);

        //ByMonth & ByMonthDay
        List<DateTime> Actual_Output = ActualResult(new DateTime(2019, 8, 16), "FREQ=YEARLY;INTERVAL=1;UNTIL=20341019T000000Z;BYMONTHDAY=16;BYMONTH=9;");
        List<DateTime> Expected_Output = new List<DateTime>
            {
                new DateTime(2019,9,16),new DateTime(2020,9,16),new DateTime(2021,9,16),
                new DateTime(2022,9,16),new DateTime(2023,9,16),new DateTime(2024,9,16),
                new DateTime(2025,9,16),new DateTime(2026,9,16),new DateTime(2027,9,16),
                new DateTime(2028,9,16),new DateTime(2029,9,16),new DateTime(2030,9,16),
                new DateTime(2031,9,16),new DateTime(2032,9,16),new DateTime(2033,9,16),
                new DateTime(2034,9,16),
            };
        Assert.Equal(Expected_Output, Actual_Output);

        //ByMonth & ByMonthDay
        List<DateTime> ActualRes = ActualResult(new DateTime(2019, 1, 4), "FREQ=YEARLY;INTERVAL=1;UNTIL=20251019T000000Z;BYMONTHDAY=3;BYMONTH=4;");
        List<DateTime> ExpectedRes = new List<DateTime>
            {
                new DateTime(2019,4,3),new DateTime(2020,4,3),new DateTime(2021,4,3),
                new DateTime(2022,4,3),new DateTime(2023,4,3),new DateTime(2024,4,3),
                new DateTime(2025,4,3),
            };
        Assert.Equal(ExpectedRes, ActualRes);

        //ByMonth & ByMonthDay
        List<DateTime> Actualvar = ActualResult(new DateTime(2019, 1, 4), "FREQ=YEARLY;INTERVAL=1;UNTIL=20551130T000000Z;BYMONTHDAY=17;BYMONTH=7;");
        List<DateTime> Expectedvar = new List<DateTime>
            {
                new DateTime(2019,7,17),new DateTime(2020,7,17),new DateTime(2021,7,17),
                new DateTime(2022,7,17),new DateTime(2023,7,17),new DateTime(2024,7,17),
                new DateTime(2025,7,17),new DateTime(2026,7,17),new DateTime(2027,7,17),
                new DateTime(2028,7,17),new DateTime(2029,7,17),new DateTime(2030,7,17),
                new DateTime(2031,7,17),new DateTime(2032,7,17),new DateTime(2033,7,17),
                new DateTime(2034,7,17),new DateTime(2035,7,17),new DateTime(2036,7,17),
                new DateTime(2037,7,17),new DateTime(2038,7,17),new DateTime(2039,7,17),
                new DateTime(2040,7,17),new DateTime(2041,7,17),new DateTime(2042,7,17),
                new DateTime(2043,7,17),new DateTime(2044,7,17),new DateTime(2045,7,17),
                new DateTime(2046,7,17),new DateTime(2047,7,17),new DateTime(2048,7,17),
                new DateTime(2049,7,17),new DateTime(2050,7,17),new DateTime(2051,7,17),
                new DateTime(2052,7,17),new DateTime(2053,7,17),new DateTime(2054,7,17),
                new DateTime(2055,7,17),
            };
        Assert.Equal(Expectedvar, Actualvar);

        //ByMonth & ByMonthDay
        List<DateTime> Actualvariable = ActualResult(new DateTime(2019, 1, 4), "FREQ=YEARLY;INTERVAL=1;UNTIL=20551130T000000Z;BYMONTHDAY=31;BYMONTH=5;");
        List<DateTime> Expectedvariable = new List<DateTime>
            {
                new DateTime(2019,5,31),new DateTime(2020,5,31),new DateTime(2021,5,31),
                new DateTime(2022,5,31),new DateTime(2023,5,31),new DateTime(2024,5,31),
                new DateTime(2025,5,31),new DateTime(2026,5,31),new DateTime(2027,5,31),
                new DateTime(2028,5,31),new DateTime(2029,5,31),new DateTime(2030,5,31),
                new DateTime(2031,5,31),new DateTime(2032,5,31),new DateTime(2033,5,31),
                new DateTime(2034,5,31),new DateTime(2035,5,31),new DateTime(2036,5,31),
                new DateTime(2037,5,31),new DateTime(2038,5,31),new DateTime(2039,5,31),
                new DateTime(2040,5,31),new DateTime(2041,5,31),new DateTime(2042,5,31),
                new DateTime(2043,5,31),new DateTime(2044,5,31),new DateTime(2045,5,31),
                new DateTime(2046,5,31),new DateTime(2047,5,31),new DateTime(2048,5,31),
                new DateTime(2049,5,31),new DateTime(2050,5,31),new DateTime(2051,5,31),
                new DateTime(2052,5,31),new DateTime(2053,5,31),new DateTime(2054,5,31),
                new DateTime(2055,5,31),
            };
        Assert.Equal(Expectedvariable, Actualvariable);

        ////TO CHECK RECURRENCE FREQUENCY YEARLY WITH NEVER

        //ByMonth & ByMonthDay
        List<DateTime> Actual_out = ActualResult(new DateTime(2019, 1, 4), "FREQ=YEARLY;INTERVAL=1;BYMONTHDAY=4;BYMONTH=12;");
        List<DateTime> Expected_out = new List<DateTime>
            {
                new DateTime(2019,12,4),new DateTime(2020,12,4),new DateTime(2021,12,4),
                new DateTime(2022,12,4),new DateTime(2023,12,4),new DateTime(2024,12,4),
                new DateTime(2025,12,4),new DateTime(2026,12,4),new DateTime(2027,12,4),
                new DateTime(2028,12,4),new DateTime(2029,12,4),new DateTime(2030,12,4),
                new DateTime(2031,12,4),new DateTime(2032,12,4),new DateTime(2033,12,4),
                new DateTime(2034,12,4),new DateTime(2035,12,4),new DateTime(2036,12,4),
                new DateTime(2037,12,4),new DateTime(2038,12,4),new DateTime(2039,12,4),
                new DateTime(2040,12,4),new DateTime(2041,12,4),new DateTime(2042,12,4),
                new DateTime(2043,12,4),new DateTime(2044,12,4),new DateTime(2045,12,4),
                new DateTime(2046,12,4),new DateTime(2047,12,4),new DateTime(2048,12,4),
                new DateTime(2049,12,4),new DateTime(2050,12,4),new DateTime(2051,12,4),
                new DateTime(2052,12,4),new DateTime(2053,12,4),new DateTime(2054,12,4),
                new DateTime(2055,12,4),new DateTime(2056,12,4),new DateTime(2057,12,4),
                new DateTime(2058,12,4),new DateTime(2059,12,4),new DateTime(2060,12,4),
                new DateTime(2061,12,4),
            };
        Assert.Equal(Expected_out, Actual_out);

        //ByMonth & ByMonthDay
        List<DateTime> ActualVals = ActualResult(new DateTime(2019, 1, 4), "FREQ=YEARLY;INTERVAL=1;BYMONTHDAY=14;BYMONTH=1;");
        List<DateTime> ExpectedVals = new List<DateTime>
            {
                new DateTime(2019,1,14),new DateTime(2020,1,14),new DateTime(2021,1,14),
                new DateTime(2022,1,14),new DateTime(2023,1,14),new DateTime(2024,1,14),
                new DateTime(2025,1,14),new DateTime(2026,1,14),new DateTime(2027,1,14),
                new DateTime(2028,1,14),new DateTime(2029,1,14),new DateTime(2030,1,14),
                new DateTime(2031,1,14),new DateTime(2032,1,14),new DateTime(2033,1,14),
                new DateTime(2034,1,14),new DateTime(2035,1,14),new DateTime(2036,1,14),
                new DateTime(2037,1,14),new DateTime(2038,1,14),new DateTime(2039,1,14),
                new DateTime(2040,1,14),new DateTime(2041,1,14),new DateTime(2042,1,14),
                new DateTime(2043,1,14),new DateTime(2044,1,14),new DateTime(2045,1,14),
                new DateTime(2046,1,14),new DateTime(2047,1,14),new DateTime(2048,1,14),
                new DateTime(2049,1,14),new DateTime(2050,1,14),new DateTime(2051,1,14),
                new DateTime(2052,1,14),new DateTime(2053,1,14),new DateTime(2054,1,14),
                new DateTime(2055,1,14),new DateTime(2056,1,14),new DateTime(2057,1,14),
                new DateTime(2058,1,14),new DateTime(2059,1,14),new DateTime(2060,1,14),
                new DateTime(2061,1,14),
            };
        Assert.Equal(ExpectedVals, ActualVals);

        //ByMonth & ByMonthDay
        List<DateTime> Actual_Val = ActualResult(new DateTime(2019, 1, 4), "FREQ=YEARLY;INTERVAL=2;BYMONTHDAY=7;BYMONTH=8;");
        List<DateTime> Expected_Val = new List<DateTime>
            {
                new DateTime(2019,8,7),new DateTime(2021,8,7),new DateTime(2023,8,7),
                new DateTime(2025,8,7),new DateTime(2027,8,7),new DateTime(2029,8,7),
                new DateTime(2031,8,7),new DateTime(2033,8,7),new DateTime(2035,8,7),
                new DateTime(2037,8,7),new DateTime(2039,8,7),new DateTime(2041,8,7),
                new DateTime(2043,8,7),new DateTime(2045,8,7),new DateTime(2047,8,7),
                new DateTime(2049,8,7),new DateTime(2051,8,7),new DateTime(2053,8,7),
                new DateTime(2055,8,7),new DateTime(2057,8,7),new DateTime(2059,8,7),
                new DateTime(2061,8,7),new DateTime(2063,8,7),new DateTime(2065,8,7),
                new DateTime(2067,8,7),new DateTime(2069,8,7),new DateTime(2071,8,7),
                new DateTime(2073,8,7),new DateTime(2075,8,7),new DateTime(2077,8,7),
                new DateTime(2079,8,7),new DateTime(2081,8,7),new DateTime(2083,8,7),
                new DateTime(2085,8,7),new DateTime(2087,8,7),new DateTime(2089,8,7),
                new DateTime(2091,8,7),new DateTime(2093,8,7),new DateTime(2095,8,7),
                new DateTime(2097,8,7),new DateTime(2099,8,7),new DateTime(2101,8,7),
                new DateTime(2103,8,7),
            };
        Assert.Equal(Expected_Val, Actual_Val);

        //ByMonth, ByDay & Bysetpos
        List<DateTime> Actual_output = ActualResult(new DateTime(2019, 3, 12), "FREQ=YEARLY;INTERVAL=1;BYDAY=TH;BYSETPOS=2;BYMONTH=4;");
        List<DateTime> Expected_output = new List<DateTime>
            {
                new DateTime(2019,4,11),new DateTime(2020,4,9),new DateTime(2021,4,8),
                new DateTime(2022,4,14),new DateTime(2023,4,13),new DateTime(2024,4,11),
                new DateTime(2025,4,10),new DateTime(2026,4,9),new DateTime(2027,4,8),
                new DateTime(2028,4,13),new DateTime(2029,4,12),new DateTime(2030,4,11),
                new DateTime(2031,4,10),new DateTime(2032,4,8),new DateTime(2033,4,14),
                new DateTime(2034,4,13),new DateTime(2035,4,12),new DateTime(2036,4,10),
                new DateTime(2037,4,9),new DateTime(2038,4,8),new DateTime(2039,4,14),
                new DateTime(2040,4,12),new DateTime(2041,4,11),new DateTime(2042,4,10),
                new DateTime(2043,4,9),new DateTime(2044,4,14),new DateTime(2045,4,13),
                new DateTime(2046,4,12),new DateTime(2047,4,11),new DateTime(2048,4,9),
                new DateTime(2049,4,8),new DateTime(2050,4,14),new DateTime(2051,4,13),
                new DateTime(2052,4,11),new DateTime(2053,4,10),new DateTime(2054,4,9),
                new DateTime(2055,4,8),new DateTime(2056,4,13),new DateTime(2057,4,12),
                new DateTime(2058,4,11),new DateTime(2059,4,10),new DateTime(2060,4,8),
                new DateTime(2061,4,14),
            };
        Assert.Equal(Expected_output, Actual_output);

        ////ByMonth, ByDay & Bysetpos  ------
        //List<DateTime> Actual_ = ActualResult(new DateTime(2019, 3, 12), "FREQ=YEARLY;INTERVAL=1;BYDAY=SA;BYSETPOS=4;BYMONTH=10;");
        //List<DateTime> Expected_ = new List<DateTime>
        //    {
        //        new DateTime(2019,10,26),new DateTime(2020,10,24),new DateTime(2021,10,23),
        //        new DateTime(2022,10,22),new DateTime(2023,10,28),new DateTime(2024,10,26),
        //        new DateTime(2025,10,25),new DateTime(2026,10,24),new DateTime(2027,10,23),
        //        new DateTime(2028,10,28),new DateTime(2029,10,27),new DateTime(2030,10,26),
        //        new DateTime(2031,10,25),new DateTime(2032,10,23),new DateTime(2033,10,22),
        //        new DateTime(2034,10,28),new DateTime(2035,10,27),new DateTime(2036,10,25),
        //        new DateTime(2037,10,24),new DateTime(2038,10,23),new DateTime(2039,10,22),
        //        new DateTime(2040,10,27),new DateTime(2041,10,26),new DateTime(2042,10,25),
        //        new DateTime(2043,10,24),new DateTime(2044,10,22),new DateTime(2045,10,28),
        //        new DateTime(2046,10,27),new DateTime(2047,10,26),new DateTime(2048,10,24),
        //        new DateTime(2049,10,23),new DateTime(2050,10,22),new DateTime(2051,10,28),
        //        new DateTime(2052,10,26),new DateTime(2053,10,25),new DateTime(2054,10,24),
        //        new DateTime(2055,10,23),new DateTime(2056,10,28),new DateTime(2057,10,27),
        //        new DateTime(2058,10,26),new DateTime(2059,10,25),new DateTime(2060,10,23),
        //        new DateTime(2061,10,22),
        //    };
        //Assert.Equal(Expected_, Actual_);

        // ST issue -> ES-896441
        List<DateTime> Actual_st = ActualResult(new DateTime(2024, 1, 1), "FREQ=YEARLY;BYMONTH=1;BYDAY=SU,MO,TU,WE,TH,FR,SA;UNTIL=20250131T235959Z;");
        List<DateTime> Excepted_st = new List<DateTime>
        {
            new DateTime(2024,1,1), new DateTime(2024,1,2), new DateTime(2024,1,3),
            new DateTime(2024,1,4), new DateTime(2024,1,5), new DateTime(2024,1,6),
            new DateTime(2024,1,7), new DateTime(2024,1,8), new DateTime(2024,1,9),
            new DateTime(2024,1,10), new DateTime(2024,1,11), new DateTime(2024,1,12),
            new DateTime(2024,1,13), new DateTime(2024,1,14), new DateTime(2024,1,15),
            new DateTime(2024,1,16), new DateTime(2024,1,17), new DateTime(2024,1,18),
            new DateTime(2024,1,19), new DateTime(2024,1,20), new DateTime(2024,1,21),
            new DateTime(2024,1,22), new DateTime(2024,1,23), new DateTime(2024,1,24),
            new DateTime(2024,1,25), new DateTime(2024,1,26), new DateTime(2024,1,27),
            new DateTime(2024,1,28), new DateTime(2024,1,29), new DateTime(2024,1,30),
            new DateTime(2024,1,31), new DateTime(2025,1,1), new DateTime(2025,1,2),
            new DateTime(2025,1,3), new DateTime(2025,1,4), new DateTime(2025,1,5),
            new DateTime(2025,1,6), new DateTime(2025,1,7), new DateTime(2025,1,8),
            new DateTime(2025,1,9), new DateTime(2025,1,10), new DateTime(2025,1,11),
            new DateTime(2025,1,12), new DateTime(2025,1,13), new DateTime(2025,1,14),
            new DateTime(2025,1,15), new DateTime(2025,1,16), new DateTime(2025,1,17),
            new DateTime(2025,1,18), new DateTime(2025,1,19), new DateTime(2025,1,20),
            new DateTime(2025,1,21), new DateTime(2025,1,22), new DateTime(2025,1,23),
            new DateTime(2025,1,24), new DateTime(2025,1,25), new DateTime(2025,1,26),
            new DateTime(2025,1,27), new DateTime(2025,1,28), new DateTime(2025,1,29),
            new DateTime(2025,1,30), new DateTime(2025,1,31)
        };
        Assert.Equal(Excepted_st, Actual_st);
    }


}