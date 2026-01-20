# CFBPollNew

### About

This is the code for my computer poll for college football. Originally started in 2018 just to see if I could. This repository started as a rewrite of that original code ([found here](https://github.com/taylorleprechaun/CFBPoll)) and has since been updated and upgraded many times.

This poll uses team statistics and game results to calculate ratings for each team and rank who it thinks is the best team in college football. The rating algoritm gives teams a Score by awarding or deducting points based on some key rating factors. With all the Scores calculated, the teams can be ranked based on whoever's is highest. In the rankings table, the Rating represents each team's Score as a percentage of the #1 team's. If Florida is #1 (in my dreams) with a Score of 50 points, then every team's Score is divided by 50 to calculate their Rating.

Part of the Massey Composite (Steinberg/TSS).

### Recent changes

* 10/5/2025: Summer cleaning Part 4. Pivoted from my in-progress shift to a DB-driven design to entirely using the CFBDataAPI. More work is needed on this still.
* 10/11/2025: Summer cleaning Part 5. Finished the conversion to use the CFBDataAPI as the primary data provider for this computer poll.
* 11/2/2025: Update data output format.
* 12/2/2025: Added the ability to run the poll for future game scenarios.

### Rankings (Updated 1/20/2026)

**Week 17 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Indiana | 1.0000 | 16-0 | 0.6137 | 9
2 | Oregon | 0.9229 | 13-2 | 0.6142 | 8
3 | Ohio State | 0.9104 | 12-2 | 0.6026 | 15
4 | BYU | 0.9015 | 12-2 | 0.5977 | 18
5 | Miami | 0.8963 | 13-3 | 0.6191 | 6
6 | Ole Miss | 0.8927 | 13-2 | 0.5792 | 33
7 | Texas Tech | 0.8883 | 12-2 | 0.5674 | 42
8 | Georgia | 0.8878 | 12-2 | 0.5813 | 29
9 | Texas A&M | 0.8541 | 11-2 | 0.5474 | 66
10 | Oklahoma | 0.8497 | 10-3 | 0.5951 | 21
11 | Utah | 0.8493 | 11-2 | 0.5312 | 87
12 | Alabama | 0.8457 | 11-4 | 0.6119 | 10
13 | Notre Dame | 0.8442 | 10-2 | 0.5498 | 63
14 | North Texas | 0.8297 | 12-2 | 0.5432 | 71
15 | Virginia | 0.8226 | 11-3 | 0.5428 | 74
16 | James Madison | 0.8180 | 12-2 | 0.5281 | 91
17 | Texas | 0.8164 | 10-3 | 0.5432 | 70
18 | Illinois | 0.8096 | 9-4 | 0.5958 | 20
19 | Navy | 0.8086 | 11-2 | 0.5315 | 86
20 | Vanderbilt | 0.8060 | 10-3 | 0.5311 | 88
21 | Iowa | 0.8003 | 9-4 | 0.5823 | 28
22 | Tulane | 0.7988 | 11-3 | 0.5592 | 51
23 | USC | 0.7983 | 9-4 | 0.5772 | 35
24 | Michigan | 0.7876 | 9-4 | 0.5653 | 46
25 | Arizona | 0.7861 | 9-4 | 0.5533 | 58

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2025/2025-Week%2017%20NCG.md)

#### Observations and Notes (Updated 1/20/2026)

* Congrats to Indiana for winning their first national title! I simulated the possible results from the semifinals on and they were destined to finish #1 no matter what (like Oregon was last year). Maybe something to think about with the ideas I have for improving my rating algorithm.

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

### TODO List (Updated 11/2/2025)

1. Finish data source conversion. I pivoted from my switch to a DB-driven design to now using the CFBDataAPI. I did not convert the code which handles early season rating adjustments nor any of the prediction code. Which leads directly into points #2 and #3, where I wanted to make changes to those anyway.

2. Improve early season ratings (recruiting info, returning production stats, etc.). Look into the way Strength of Schedule is calculated and weighted in the early season to make sure it is not giving too much credit to the previous season's data.

3. Improve prediction algorithm. The goal of this is: Winner >70%, ATS >50%, OU >50%, and minimizing the RMSE of my score predictions. No idea how realistic these numbers are. I have [this site](https://www.thepredictiontracker.com/ncaaresults.php) bookmarked that someone mentioned to me on r/CFB with the results of a bunch of predictive algorithms that I will use to benchmark my performance.

4. Improve the console app for running the poll to make it a little friendlier to use. I may also skip this and go directly to #5.

5. Build a basic UI for the poll. The UI would give me all the functionality from my current console app plus more. Depending on how this goes I may look into getting a real website to host this instead of just using GitHub out of convenience.

6. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2025.

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

The rankings are split between pre-CFP and CFP eras. This was because the teams in the CFP get small bumps from playing extra games against other high quality teams.
I'm probably going to have to split the CFP era into 4 and 12 team sections as well due to teams getting ever more possible bumps, but not yet.

*New additions for the 2025 season!*

* Indiana not only finished #1 this season, they recorded the best ever rating my poll has handed out! Their 42.487 dethrones 2018 Clemson from the spot they've held for seven years.
* Massachussets is the only team to finish with a rating below 16 this season with a 14.134. This is the 2nd worst rating of the playoff era and 5th worst of all time.

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
1 | 2025 | Indiana | 42.487 | 16-0
2 | 2018 | Clemson | 42.445 | 15-0
3 | 2019 | LSU | 42.374 | 15-0
4 | 2023 | Michigan | 42.244 | 15-0
5 | 2022 | Georgia | 42.124 | 15-0

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2025 | UMass | 14.134 | 0-12
