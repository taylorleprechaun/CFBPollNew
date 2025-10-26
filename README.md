# CFBPollNew

### About

This is the code for my computer poll for college football. Originally started in 2018 just to see if I could. This repository started as a rewrite of that original code ([found here](https://github.com/taylorleprechaun/CFBPoll)) and has since been updated and upgraded many times.

This poll uses team statistics and game results to calculate ratings for each team and rank who it thinks is the best team in college football. The rating algoritm gives teams a Score by awarding or deducting points based on some key rating factors. With all the Scores calculated, the teams can be ranked based on whoever's is highest. In the rankings table, the Rating represents each team's Score as a percentage of the #1 team's. If Florida is #1 (in my dreams) with a Score of 50 points, then every team's Score is divided by 50 to calculate their Rating.

Part of the Massey Composite (Steinberg/TSS).

### Recent changes

* 10/5/2025: Summer cleaning Part 4. Pivoted from my in-progress shift to a DB-driven design to entirely using the CFBDataAPI. More work is needed on this still.
* 10/11/2025: Summer cleaning Part 5. Finished the conversion to use the CFBDataAPI as the primary data provider for this computer poll.

### Rankings (Updated 10/26/2025)

**Week 10 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Indiana | 1.0000 | 8-0 | 0.6050 | 26
2 | Ohio State | 0.9885 | 7-0 | 0.5937 | 34
3 | BYU | 0.9543 | 8-0 | 0.5518 | 71
4 | Texas A&M | 0.9419 | 8-0 | 0.5449 | 78
5 | Georgia Tech | 0.9348 | 8-0 | 0.5368 | 85
6 | Miami | 0.9201 | 6-1 | 0.6097 | 24
7 | Georgia | 0.9198 | 6-1 | 0.6187 | 20
8 | Alabama | 0.9120 | 7-1 | 0.5873 | 43
9 | Louisville | 0.9066 | 6-1 | 0.5957 | 31
10 | Ole Miss | 0.8874 | 7-1 | 0.5642 | 60
11 | Vanderbilt | 0.8839 | 7-1 | 0.5500 | 74
12 | Virginia | 0.8771 | 7-1 | 0.5433 | 79
13 | Texas Tech | 0.8699 | 7-1 | 0.5235 | 91
14 | Cincinnati | 0.8674 | 7-1 | 0.5306 | 88
15 | Navy | 0.8579 | 7-0 | 0.4765 | 122
16 | Houston | 0.8556 | 7-1 | 0.5181 | 95
17 | Oregon | 0.8546 | 7-1 | 0.5033 | 103
18 | Washington | 0.8534 | 6-2 | 0.6011 | 29
19 | Michigan | 0.8460 | 6-2 | 0.5878 | 40
20 | Utah | 0.8422 | 6-2 | 0.5836 | 47
21 | Oklahoma | 0.8378 | 6-2 | 0.5865 | 44
22 | Nebraska | 0.8350 | 6-2 | 0.5769 | 52
23 | Notre Dame | 0.8233 | 5-2 | 0.6040 | 27
24 | Tulane | 0.8229 | 6-1 | 0.5352 | 86
25 | Tennessee | 0.8197 | 6-2 | 0.5556 | 66

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2025/2025-Week%2010.md)

#### Observations and Notes (Updated 10/26/2025)

* We're at a point in the season where I start to feel like my rankings are actually good and not just alright. The rating algorithm has enough information to work with that it doesn't wildly overreact week to week because my data points are becoming less volatile. And it means the the actual ranking of teams is defensible (for the most part) relative to some weeks where you look at it and just wonder what's going on.
* After a few weeks now running on my new data source I gotta say this is way more convenient to run and I should have done it sooner.

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

### TODO List (Updated 10/11/2025)

1. Finish data source conversion. I pivoted from my switch to a DB-driven design to now using the CFBDataAPI. I did not convert the code which handles early season rating adjustments nor any of the prediction code. Which leads directly into points #2 and #3, where I wanted to make changes to those anyway.

2. Improve early season ratings (recruiting info, returning production stats, etc.). Look into the way Strength of Schedule is calculated and weighted in the early season to make sure it is not giving too much credit to the previous season's data.

3. Improve prediction algorithm. The goal of this is: Winner >70%, ATS >50%, OU >50%, and minimizing the RMSE of my score predictions. No idea how realistic these numbers are. I have [this site](https://www.thepredictiontracker.com/ncaaresults.php) bookmarked that someone mentioned to me on r/CFB with the results of a bunch of predictive algorithms that I will use to benchmark my performance.

4. Improve the console app for running the poll to make it a little friendlier to use. I may also skip this and go directly to #5.

5. Build a basic UI for the poll. The UI would give me all the functionality from my current console app plus more. Depending on how this goes I may look into getting a real website to host this instead of just using GitHub out of convenience.

6. Add more data print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

7. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2024.

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me. As of right now I'm not going to split into 4 vs 12 but maybe in the future I will.

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
