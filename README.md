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

### Rankings (Updated 12/7/2025)

**Week 16 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Indiana | 1.0000 | 13-0 | 0.5630 | 41
2 | Ohio State | 0.9573 | 12-1 | 0.5693 | 32
3 | Georgia | 0.9481 | 12-1 | 0.5674 | 34
4 | Texas Tech | 0.9405 | 12-1 | 0.5403 | 66
5 | Oregon | 0.9306 | 11-1 | 0.5382 | 69
6 | BYU | 0.9291 | 11-2 | 0.5961 | 13
7 | Ole Miss | 0.9233 | 11-1 | 0.5395 | 68
8 | Oklahoma | 0.9165 | 10-2 | 0.5930 | 17
9 | Texas A&M | 0.9154 | 11-1 | 0.5327 | 76
10 | Alabama | 0.8860 | 10-3 | 0.5942 | 16
11 | Miami | 0.8859 | 10-2 | 0.5429 | 62
12 | Utah | 0.8762 | 10-2 | 0.5336 | 75
13 | Notre Dame | 0.8735 | 10-2 | 0.5459 | 59
14 | Vanderbilt | 0.8707 | 10-2 | 0.5289 | 84
15 | James Madison | 0.8651 | 12-1 | 0.5017 | 103
16 | USC | 0.8521 | 9-3 | 0.5651 | 37
17 | Michigan | 0.8493 | 9-3 | 0.5628 | 42
18 | North Texas | 0.8466 | 11-2 | 0.5304 | 80
19 | Tulane | 0.8409 | 11-2 | 0.5293 | 83
20 | Arizona | 0.8406 | 9-3 | 0.5434 | 61
21 | Texas | 0.8393 | 9-3 | 0.5469 | 56
22 | Virginia | 0.8353 | 10-3 | 0.5298 | 81
23 | Navy | 0.8261 | 9-2 | 0.5339 | 73
24 | Illinois | 0.8172 | 8-4 | 0.5843 | 22
25 | Georgia Tech | 0.8132 | 9-3 | 0.5233 | 88

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2025/2025-Week%2016%20CCG.md)

#### Observations and Notes (Updated 12/7/2025)

* The playoff teams (according to my computer) are:

Seed | Team | Qualification
---|---|---
1 | Indiana | Big Ten Champ
2 | Ohio State | At-Large
3 | Georgia | SEC Champ
4 | Texas Tech | Big 12 Champ
5 | Oregon | At-Large
6 | BYU | At-Large
7 | Ole Miss | At-Large
8 | Oklahoma | At-Large
9 | Texas A&M | At-Large
10 | Alabama | At-Large
11 | James Madison | Sun Belt Champ
12 | Tulane | American Champ

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
