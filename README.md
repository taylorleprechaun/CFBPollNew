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

### Rankings (Updated 9/29/2025)

**Week 6 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Indiana | 1.0000 | 5-0 | 0.6571 | 12
2 | Ohio State | 0.9744 | 4-0 | 0.6268 | 21
3 | Mississippi | 0.9413 | 5-0 | 0.5990 | 40
4 | Oklahoma | 0.9315 | 4-0 | 0.6153 | 28
5 | Louisville | 0.9272 | 4-0 | 0.5778 | 63
6 | Texas A&M | 0.9201 | 4-0 | 0.5829 | 55
7 | Vanderbilt | 0.9179 | 5-0 | 0.5693 | 67
8 | Maryland | 0.9138 | 4-0 | 0.5848 | 49
9 | Miami FL | 0.9110 | 4-0 | 0.5437 | 93
10 | Texas Tech | 0.9109 | 4-0 | 0.5457 | 89
11 | Illinois | 0.9092 | 4-1 | 0.6930 | 4
12 | Iowa State | 0.9084 | 5-0 | 0.5458 | 88
13 | Brigham Young | 0.9080 | 4-0 | 0.5252 | 103
14 | Arizona State | 0.8985 | 4-1 | 0.6742 | 7
15 | Houston | 0.8949 | 4-0 | 0.5605 | 77
16 | Missouri | 0.8872 | 5-0 | 0.5076 | 119
17 | Oregon | 0.8834 | 5-0 | 0.4814 | 130
18 | Tennessee | 0.8815 | 4-1 | 0.6515 | 15
19 | Delaware | 0.8782 | 3-1 | 0.5556 | 79
20 | Georgia Tech | 0.8772 | 5-0 | 0.5294 | 97
21 | Navy | 0.8768 | 4-0 | 0.5512 | 83
22 | Louisiana State | 0.8579 | 4-1 | 0.6236 | 26
23 | UNLV | 0.8572 | 4-0 | 0.4958 | 124
24 | Mississippi State | 0.8533 | 4-1 | 0.6563 | 13
25 | Memphis | 0.8425 | 5-0 | 0.4921 | 126

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2025/2025-Week%2006.md)

#### Observations and Notes (Updated 9/29/2025)

* I'm absolutely here for #1 Indiana.
* I was very surprised by this ranking, especially compared to the previous week. It's actually kind of crazy looking in a few spots. The ones that stood out to me the most were Oregon and Penn State. Previous #2 Oregon beat previous #3 Penn State and then they both dropped to #17 and #31, respectively, and Oregon's strength of schedule fell from 26 to 130. The logic to help stabilize early season rating volatility phases out as the season goes on and there is barely any of it left still propping teams up. The sudden shift in strength of schedule I might need to look at. It is supposed to balance out proportionally, but it is possible it was giving Oregon too much strength of schedule credit for the previous season. Added to my TODO list down below.

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

### TODO List (Updated 9/29/2025)

1. Finish data source conversion. I am partially through changing my data source from Excel files exported from sports-reference to using a database to hold the data and query it for everything. As of writing this, I can upload data from those Excel files into the DB and wrote a tool which will do that automatically from all my old data. Next steps are roughly: upload the rest of the data, extensive validation to make sure the imported data is correct, build code/procs to pull the data, use that code to run the poll, run previous polls with the new data source to validate the rating output is the same.

2. Improve early season ratings (recruiting info, returning production stats, etc.). Look into the way Strength of Schedule is calculated and weighted in the early season to make sure it is not giving too much credit to the previous season's data.

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
