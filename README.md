# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 8/16/2025: Summer cleaning Part 1. Rearranged a lot of code and started moving towards a more modular and DB-driven design.
* 8/17/2025: Summer cleaning Part 2. More work towards DB-driven design and loading data into the system.
* 8/24/2025: Summer cleaning Part 3. Even more work towards DB-driven design and loading data into the system.

### Rankings (Updated 9/16/2025)

**Week 4 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Ohio State | 1.0000 | 3-0 | 0.6232 | 6
2 | Oregon | 0.9977 | 3-0 | 0.5932 | 19
3 | Penn State | 0.9672 | 3-0 | 0.5810 | 26
4 | Georgia | 0.9592 | 3-0 | 0.6011 | 14
5 | Indiana | 0.9472 | 3-0 | 0.5338 | 84
6 | Brigham Young | 0.9438 | 2-0 | 0.5240 | 90
7 | Illinois | 0.9374 | 3-0 | 0.5499 | 67
8 | Iowa State | 0.9302 | 4-0 | 0.5505 | 64
9 | Miami FL | 0.9289 | 3-0 | 0.5418 | 76
10 | Louisiana State | 0.9283 | 3-0 | 0.5805 | 29
11 | Missouri | 0.9279 | 3-0 | 0.5382 | 81
12 | Louisville | 0.9269 | 2-0 | 0.5794 | 31
13 | Mississippi | 0.9220 | 3-0 | 0.5464 | 73
14 | Texas A&M | 0.9091 | 3-0 | 0.5785 | 33
15 | USC | 0.9041 | 3-0 | 0.5729 | 36
16 | Texas Tech | 0.9039 | 3-0 | 0.5465 | 72
17 | Washington | 0.9009 | 2-0 | 0.6026 | 13
18 | Oklahoma | 0.8986 | 3-0 | 0.6164 | 8
19 | Nebraska | 0.8953 | 3-0 | 0.5576 | 55
20 | Vanderbilt | 0.8950 | 3-0 | 0.5654 | 43
21 | Navy | 0.8949 | 3-0 | 0.5524 | 61
22 | Georgia Tech | 0.8924 | 3-0 | 0.5792 | 32
23 | Texas Christian | 0.8886 | 2-0 | 0.5078 | 107
24 | UNLV | 0.8847 | 3-0 | 0.5021 | 116
25 | Central Florida | 0.8689 | 2-0 | 0.5913 | 21

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2025/2025-Week%2004.md)

#### Observations and Notes (Updated 9/11/2025)

* First poll of the season is out. As usual it's got some junk in it that will clear up as we get additional data points over time. I would have had this out Tuesday night but something came up and I couldn't do anything for a few days.

#### Predictions (Updated 9/11/2025)

I've decided not to generate game predictions this season unless I get a huge amount of sudden free time. I didn't have the time in the offseason that I wanted to to make the changes I had planned and won't have time to make them for a while due to work and life stuff. Around the playoffs I'll probably run everything through my current algorithm just to do something, but that's about all you can expect.

2024 Season Results:
* Winner: 510 - 238 (68.2%)
* ATS: 364 - 394 (48.0%)
* O/U: 374 - 384 (49.3%)

2023 Season Results:
* Winner: 507 - 232 (68.6%)
* ATS: 365 - 374 (49.4%)
* O/U: 366 - 373 (49.5%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)

### TODO List (Updated 9/11/2025)

1. Finish data source conversion. I am partially through changing my data source from Excel files exported from sports-reference to using a database to hold the data and query it for everything. As of writing this, I can upload data from those Excel files into the DB and wrote a tool which will do that automatically from all my old data. Next steps are roughly: upload the rest of the data, extensive validation to make sure the imported data is correct, build code/procs to pull the data, use that code to run the poll, run previous polls with the new data source to validate the rating output is the same.

2. Improve early season ratings (recruiting info, returning production stats, etc.).

3. Improve prediction algorithm. The goal of this is: Winner >70%, ATS >50%, OU >50%, and minimizing the RMSE of my score predictions. No idea how realistic these numbers are. I have [this site](https://www.thepredictiontracker.com/ncaaresults.php) bookmarked that someone mentioned to me on r/CFB with the results of a bunch of predictive algorithms that I will use to benchmark my performance.

4. Improve the console app for running the poll to make it a little friendlier to use. I may also skip this and go directly to #5.

5. Build a basic UI for the poll. The UI would give me all the functionality from my current console app plus more. Depending on how this goes I may look into getting a real website to host this instead of just using GitHub out of convenience.

6. Add more data print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

7. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me. As of right now I'm not going to split into 4 vs 12 but maybe in the future I will

*New additions for the 2024 season!*

* No one cracked 40 points so no one is making it into the BOAT section for 2024. Oregon came closest at 39.962 and Ohio State was a little behind at 39.802
* Kent State repeats this year as worst team in FBS. They finished with a rating of 15.735, placing them at 9th worst in the Playoff Era

**The top 5 Best of all Time (pre-CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2001 | Miami FL | 42.309 | 12-0
2 | 2009 | Alabama | 41.756 | 14-0
3 | 2010 | Auburn | 41.464 | 14-0
4 | 2005 | Texas | 41.291 | 13-0
5 | 2000 | Oklahoma | 41.246 | 13-0

**The top 5 Best of all Time (CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2018 | Clemson | 42.445 | 15-0
2 | 2019 | LSU | 42.374 | 15-0
3 | 2023 | Michigan | 42.244 | 15-0
4 | 2022 | Georgia | 42.124 | 15-0
5 | 2015 | Alabama | 41.615 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
